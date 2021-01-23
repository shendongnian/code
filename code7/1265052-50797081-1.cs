    **public class BackgroundActionTask
    {
        private const string Task_NAME = "BackgroundTasker";
        public async static void RunBacgroundTask(bool run)
        {
            if (run)
            {
                StorageHelper.SaveLocalSetting(BuiltSettings.BackroundTaskKey, Task_NAME);
            }
            else
            {
                if (StorageHelper.LocalSettings.Values.ContainsKey(BuiltSettings.BackroundTaskKey))
                {
                    StorageHelper.LocalSettings.Values.Remove(BuiltSettings.BackroundTaskKey);
                }
            }
            if (StorageHelper.LocalSettings.Values.ContainsKey(BuiltSettings.BackroundTaskKey))
            {
                foreach (var task in BackgroundTaskRegistration.AllTasks)
                {
                    task.Value.Unregister(true);
                }
                var access = await BackgroundExecutionManager.RequestAccessAsync();
                switch (access)
                {
                    case BackgroundAccessStatus.Unspecified:
                        break;
                    case BackgroundAccessStatus.AllowedMayUseActiveRealTimeConnectivity:
                        break;
                    case BackgroundAccessStatus.AllowedWithAlwaysOnRealTimeConnectivity:
                        break;
                    case BackgroundAccessStatus.Denied:
                        break;
                    default:
                        break;
                }
                try
                {
                    var task = new BackgroundTaskBuilder
                    {
                        Name = Task_NAME,
                        TaskEntryPoint = typeof(BackgroundTasker.BackgroundTaskUpdater).ToString()
                    };
                    var trigger = new TimeTrigger(12 * 60, false);
                    task.SetTrigger(trigger);
                    task.Register();
                }
                catch (Exception ex)
                {
                    DialogHelper.DisplayMessageDebug(ex.Message);
                }
            }
            else
            {
                foreach (var task in BackgroundTaskRegistration.AllTasks)
                {
                    task.Value.Unregister(true);
                }
            }
        }**
