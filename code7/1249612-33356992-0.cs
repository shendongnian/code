            using (TaskService ts = new TaskService())
            {
                try
                {
                    //Create a new task definition and assign properties
                    TaskDefinition td = ts.NewTask();
                    td.Principal.RunLevel = TaskRunLevel.Highest;
                    td.RegistrationInfo.Description = "Paulos Task";
                    td.Triggers.Add(new TimeTrigger() { StartBoundary = Convert.ToDateTime("01-01-2003 00:00:01") });
                    // Create an action that will launch PauloApp whenever the trigger fires
                    td.Actions.Add(new ExecAction("PauloApp.exe", "", Environment.ExpandEnvironmentVariables(@"%ProgramFiles%\Paulo")));
                    td.Settings.DisallowStartIfOnBatteries = false;
                    td.Settings.StopIfGoingOnBatteries = false;
                    ts.RootFolder.RegisterTaskDefinition("PaulosTask", td,
                       TaskCreation.CreateOrUpdate, "Administrators", null,
                       TaskLogonType.Group);
                    // Register the task in the root folder
                    Microsoft.Win32.TaskScheduler.Task t = ts.FindTask("PaulosTask");
                    if (t != null)
                        t.Run();
                    else
                        //could not find PaulosTask
                }//end try
                catch (Exception e)
                {
                }
            }//end using
