    private static void ListenToKeyEvents()
    {
        int timeToReact = 1000; // your time for user to react in ms
        ConsoleKeyInfo x = new ConsoleKeyInfo();
        Stopwatch s = new Stopwatch();
        s.Start();        
 
        while (s.ElapsedMilliseconds < timeToReact && !Console.KeyAvailable && x.Key != ConsoleKey.Escape)
        {
           // ..... your code 
        }
        s.Stop();
    }
    Task taskA = new Task(() => 
    {
       // Whether or not user pressed arrows 
       // ListenToKeyEvents finishes executing
       // DropTetraMino is invoked and it is repeated 
       while(gameIsOn)
       {
           ListenToKeyEvents();
           DropTetramino();
       }
    });
    
    // Start the task.
    taskA.Start();    
    taskA.Wait();
