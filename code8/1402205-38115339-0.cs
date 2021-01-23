    taskService.RootFolder.DeleteTask("TaskName", false);
                                
    var taskDefinition = taskService.NewTask();                        
    taskDefinition.RegistrationInfo.Author = WindowsIdentity.GetCurrent().Name;
                            
    taskDefinition.RegistrationInfo.Description = "Runs Task with arguments: " + arguments;
    taskDefinition.Principal.LogonType = TaskLogonType.InteractiveTokenOrPassword;
                                
    var action = new ExecAction(path, arguments);
    taskDefinition.Actions.Add(action);
    taskService.RootFolder.RegisterTaskDefinition("TaskName", taskDefinition, TaskCreation.Create, "domain\\user", password, TaskLogonType.InteractiveTokenOrPassword);
                            
    //get task:
    var task = taskService.RootFolder.GetTasks().Where(a => a.Name == ("TaskName").FirstOrDefault();
    log.Info("Start task " + task.Name + " with arguemtns " + arguments);
                            
    try
    {
    	task.Run();
    }
    catch (Exception ex)
    {
        log.Error("Error starting task in TaskSheduler with message: " + ex.Message);
    }
