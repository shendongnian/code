    foreach (var task in BackgroundTaskRegistration.AllTasks)
            {
                if (task.Value.Name == BackgroundTaskSample.ApplicationTriggerTaskName)
                {
                    AttachProgressAndCompletedHandlers(task.Value);
                    BackgroundTaskSample.UpdateBackgroundTaskStatus(BackgroundTaskSample.ApplicationTriggerTaskName, true);
                    break;
                }
            }
            trigger = new ApplicationTrigger();
