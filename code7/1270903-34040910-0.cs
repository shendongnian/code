    internal int SomeFunction()
    {
        Task<AddNodeResult> task1 = new Task<DeviceInfo>(() => AddNodeToNetwork());
        task1.Start();            
        Task<ZWNode> task2 = task1.ContinueWith(task => GetCommandClassesVersions(task.Result), TaskContinuationOptions.OnlyOnRanToCompletion);       
        Task task3 = task2.ContinueWith(task => GetManufacturerSpecific(task.Result), TaskContinuationOptions.OnlyOnRanToCompletion);
        Task task4 = task3.ContinueWith(task => PersistAddedNode(task.Result), TaskContinuationOptions.OnlyOnRanToCompletion);
        return 200;
    }     
