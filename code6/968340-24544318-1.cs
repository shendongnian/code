    static void Main(string[] args)
    {
    
       Task t3 = AsyncStart().ContinueWith((ant) => { Continue(); });
    
       Console.Out.WriteLine("BEFORE"); 
       Task.WaitAll(new Task[] { t3 });
       Console.Out.WriteLine("AFTER");
    }
