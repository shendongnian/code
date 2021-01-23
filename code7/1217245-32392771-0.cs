    static void Main (string[] args)
    {
        var task = 
          MainTask()
          .ContinueWith(t => Console.WriteLine("Main State={0}", t.Status));
        task.Wait();
    }
    
    static async Task MainTask()
    {
        Console.WriteLine ("MainStarted!");
 
        await Task.Delay(1000);
        Console.WriteLine ("Waiting Ended!!");
        throw new Exception ("CustomException!");
        Console.WriteLine ("NeverReaches here!!");
    }
