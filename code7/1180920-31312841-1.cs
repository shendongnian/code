    private async void RegisterBackgroundTask()
        {
            await BackgroundExecutionManager.RequestAccessAsync();
            try
            {
                foreach (var task in BackgroundTaskRegistration.AllTasks)
                {
                    try
                    {
                        task.Value.Unregister(false);
                    }
                    catch
                    {
                        //
                    }
                }
                BackgroundTaskBuilder builder = new BackgroundTaskBuilder();
                builder.Name = "Push Notifcation Task";
                builder.TaskEntryPoint = typeof(PushNotification).FullName;
                builder.SetTrigger(new PushNotificationTrigger());
                builder.Register();
            }
            catch(Exception e)
            {
                if(e != null)
                {
                    System.Diagnostics.Debug.WriteLine(e.HResult);
                    System.Diagnostics.Debug.WriteLine(e.InnerException);
                }
            }
        }
