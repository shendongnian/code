    public sealed class MyBackgroundTask : XamlRenderingBackgroundTask
    {
        protected override async void OnRun(IBackgroundTaskInstance taskInstance)
        {
            var deferral = taskInstance.GetDeferral();
            //your code here
            deferral.Complete();
        }
     }
