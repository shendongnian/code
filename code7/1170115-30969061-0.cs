    using System;
    using System.Globalization;
    using Windows.ApplicationModel.Background;
    using Windows.Storage;
    namespace WindowsRuntimeComponent1
    {
        public sealed class MyBackgroundClass : IBackgroundTask
        {
            public void Run(IBackgroundTaskInstance taskInstance)
            {
                // Get a deferral, to prevent the task from closing prematurely if asynchronous code is still running.
                BackgroundTaskDeferral deferral = taskInstance.GetDeferral();
                // GET THIS INFO
                ApplicationDataContainer LocalSettings = ApplicationData.Current.LocalSettings;
                double elapsed = (DateTime.Now - Convert.ToDateTime(LocalSettings.Values["time stamp"], CultureInfo.InvariantCulture)).TotalMinutes;
                double remainingMinutes = (int) LocalSettings.Values["gap time minutes"] - elapsed;
                // SEE IF WE CAN DO IT NOW
                if (remainingMinutes > 15)
                {
                    // do something, otherwise, wait for the next one
                }
         
                // FINISH UP
                deferral.Complete();
            }
        }
    }
