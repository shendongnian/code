    BackgroundExecutionManager.RemoveAccess();
                //Unregister the Background Agent 
                var entry = BackgroundTaskRegistration.AllTasks.FirstOrDefault(keyval => keyval.Value.Name == "myAgent");
                if (entry.Value != null)
                {
                    entry.Value.Unregister(true);
                }
 
