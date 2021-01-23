    public sealed class BackgroundHttpClientTest : IBackgroundTask
    {
        BackgroundTaskDeferral _deferral = taskInstance.GetDeferral(); 
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            var response = await new Windows.Web.Http.HttpClient().GetAsync(new Uri("https://www.someUrl.com"));
            _deferral.Complete();
        }
    }
