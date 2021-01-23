    using (TaskService ts = new TaskService(@"\\RemoteServer"))
    {
        TaskDefinition td = ts.NewTask();
        td.RegistrationInfo.Description = "Does something";
                    
        // Create an action that will launch Notepad whenever the trigger fires
        td.Actions.Add(new ExecAction("notepad.exe", "\"c:\\Some Folder\\test.log\"", null));
    
        // Register the task in the root folder
        ts.RootFolder.RegisterTaskDefinition(@"Test", td);
    }
