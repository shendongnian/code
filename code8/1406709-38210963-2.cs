    public sealed class BackgroundHttpClientTest : IBackgroundTask
    {
        BackgroundTaskDeferral _deferral;
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            _deferral = taskInstance.GetDeferral(); 
            var response = await new Windows.Web.Http.HttpClient().GetAsync(new Uri("https://www.someUrl.com"));
            _deferral.Complete();
        }
    }
