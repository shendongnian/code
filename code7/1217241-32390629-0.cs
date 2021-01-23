    void Main(string[] args)
    {
    	Task newTask = Task.Run(MainTask);
    	newTask.ContinueWith((Task someTask) =>
       {
    	   Console.WriteLine("Main State=" + someTask.Status.ToString() + " IsFaulted=" + someTask.IsFaulted + " isComplete=" + someTask.IsCompleted);
       });
    	while (true)
    	{
    
    	}
    }
    
    static async Task MainTask()
    {
    	Console.WriteLine("MainStarted!");
    	Task someTask = Task.Run(() =>
       {
    	   Console.WriteLine("SleepStarted!");
    	   Thread.Sleep(1000);
    	   Console.WriteLine("SleepEnded!");
       });
    	await someTask;
    	Console.WriteLine("Waiting Ended!!");
    	throw new Exception("CustomException!");
    	Console.WriteLine("NeverReaches here!!");
    }
