        public sealed class bgTask : IBackgroundTask
        {
            BackgroundTaskDeferral _deferral = taskInstance.GetDeferral();
            public async void Run(IBackgroundTaskInstance taskInstance)
            {
                //Handle async stuff
                _deferral.Complete();
            }
        }
