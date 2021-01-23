    private static List<IRegisteredTask> GetReadyAndRunningTasks(
        ITaskFolder folder, 
        List<IRegisteredTask> readyAndRunningTasks = null)
    {
        if (readyAndRunningTasks == null)
        {
            readyAndRunningTasks = new List<IRegisteredTask>();
        }
        IRegisteredTaskCollection tasks = folder.GetTasks(flags: 0);
        foreach (IRegisteredTask task in tasks)
        {
            if (task.State == _TASK_STATE.TASK_STATE_READY
                || task.State == _TASK_STATE.TASK_STATE_RUNNING)
            {
                readyAndRunningTasks.Add(task);
            }
        }
        foreach (ITaskFolder subFolder in folder.GetFolders(flags: 0))
        {
            GetReadyAndRunningTasks(subFolder, readyAndRunningTasks);
        }
        return readyAndRunningTasks;
    }
