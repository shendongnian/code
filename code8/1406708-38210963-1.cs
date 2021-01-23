    public sealed class BackgroundHttpClientTest : IBackgroundTask
    {
        
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            BackgroundTaskDeferral _deferral = taskInstance.GetDeferral(); 
            var response = await new Windows.Web.Http.HttpClient().GetAsync(new Uri("https://www.someUrl.com"));
            _deferral.Complete();
        }
    }
