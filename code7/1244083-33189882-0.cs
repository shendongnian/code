        public sealed class BackgroundTask1 : IBackgroundTask
        {
            BackgroundTaskDeferral _deferral;
    
            public async void Run(IBackgroundTaskInstance taskInstance)
            {
                _deferral = taskInstance.GetDeferral();
    
                await ApplicationData.Current.LocalFolder.CreateFileAsync("test.txt"
                , CreationCollisionOption.ReplaceExisting);
    
    
                _deferral.Complete();
            }
        }
