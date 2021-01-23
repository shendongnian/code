    public static async Task Main()
    {
      var taskScheduler = new SingleThreadTaskScheduler(ApartmentState.STA);
      var taskList = new List<Task>();
      
      var updateTask = Task.Run(InstallHelper.CheckForUpdatesAsync);
      updateTask.Wait();
      taskList.Add(updateTask);
      var tasks = await Task.Factory.ContinueWhenAll(taskList.ToArray(), result => 
                        Task.Factory.StartNew( ()=>MyAppSynchronMethodToRunIn_STAThread, 
                        taskScheduler));
    }
