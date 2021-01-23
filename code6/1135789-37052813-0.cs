    public class Functions
    {
        public static async Task ProcessQueueMessage([QueueTrigger("jobqueue")] Guid jobId, TextWriter log)
        {
            for (int i = 10; i <= 100; i+=10)
            {
                Thread.Sleep(400);
    
                await CommunicateProgress(jobId, i);
            }
        }
    
        private static async Task CommunicateProgress(Guid jobId, int percentage)
        {
            var httpClient = new HttpClient();
    
            var queryString = String.Format("?jobId={0}&progress={1}", jobId, percentage);
            var request = ConfigurationManager.AppSettings["ProgressNotificationEndpoint"] + queryString;
    
            await httpClient.GetAsync(request);
        }
    }
