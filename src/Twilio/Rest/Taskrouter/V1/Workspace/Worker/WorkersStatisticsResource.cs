using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace.Worker 
{

    /// <summary>
    /// WorkersStatisticsResource
    /// </summary>
    public class WorkersStatisticsResource : Resource 
    {
        private static Request BuildFetchRequest(FetchWorkersStatisticsOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + options.PathWorkspaceSid + "/Workers/Statistics",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="options"> Fetch WorkersStatistics parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of WorkersStatistics </returns> 
        public static WorkersStatisticsResource Fetch(FetchWorkersStatisticsOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="options"> Fetch WorkersStatistics parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of WorkersStatistics </returns> 
        public static async System.Threading.Tasks.Task<WorkersStatisticsResource> FetchAsync(FetchWorkersStatisticsOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="pathWorkspaceSid"> The workspace_sid </param>
        /// <param name="minutes"> The minutes </param>
        /// <param name="startDate"> The start_date </param>
        /// <param name="endDate"> The end_date </param>
        /// <param name="taskQueueSid"> The task_queue_sid </param>
        /// <param name="taskQueueName"> The task_queue_name </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of WorkersStatistics </returns> 
        public static WorkersStatisticsResource Fetch(string pathWorkspaceSid, int? minutes = null, DateTime? startDate = null, DateTime? endDate = null, string taskQueueSid = null, string taskQueueName = null, string friendlyName = null, ITwilioRestClient client = null)
        {
            var options = new FetchWorkersStatisticsOptions(pathWorkspaceSid){Minutes = minutes, StartDate = startDate, EndDate = endDate, TaskQueueSid = taskQueueSid, TaskQueueName = taskQueueName, FriendlyName = friendlyName};
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="pathWorkspaceSid"> The workspace_sid </param>
        /// <param name="minutes"> The minutes </param>
        /// <param name="startDate"> The start_date </param>
        /// <param name="endDate"> The end_date </param>
        /// <param name="taskQueueSid"> The task_queue_sid </param>
        /// <param name="taskQueueName"> The task_queue_name </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of WorkersStatistics </returns> 
        public static async System.Threading.Tasks.Task<WorkersStatisticsResource> FetchAsync(string pathWorkspaceSid, int? minutes = null, DateTime? startDate = null, DateTime? endDate = null, string taskQueueSid = null, string taskQueueName = null, string friendlyName = null, ITwilioRestClient client = null)
        {
            var options = new FetchWorkersStatisticsOptions(pathWorkspaceSid){Minutes = minutes, StartDate = startDate, EndDate = endDate, TaskQueueSid = taskQueueSid, TaskQueueName = taskQueueName, FriendlyName = friendlyName};
            return await FetchAsync(options, client);
        }
        #endif

        /// <summary>
        /// Converts a JSON string into a WorkersStatisticsResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> WorkersStatisticsResource object represented by the provided JSON </returns> 
        public static WorkersStatisticsResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<WorkersStatisticsResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

        /// <summary>
        /// The account_sid
        /// </summary>
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        /// <summary>
        /// The cumulative
        /// </summary>
        [JsonProperty("cumulative")]
        public object Cumulative { get; private set; }
        /// <summary>
        /// The realtime
        /// </summary>
        [JsonProperty("realtime")]
        public object Realtime { get; private set; }
        /// <summary>
        /// The workspace_sid
        /// </summary>
        [JsonProperty("workspace_sid")]
        public string WorkspaceSid { get; private set; }
        /// <summary>
        /// The url
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        private WorkersStatisticsResource()
        {

        }
    }

}