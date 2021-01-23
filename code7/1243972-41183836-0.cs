    using (var tasksrvc = GetTaskService(hostName, userName, password))
    {
          tasksrvc.AddTask(
                   taskName,
                   QuickTriggerType.Daily,
                   taskFolderPath,
                   null,
                   "UserName",
                   "Password",
                   TaskLogonType.Password);                    
    }
