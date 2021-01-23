    static void Main(string[] args)
    {
        Thread.CurrentThread.Priority = ThreadPriority.Highest;
        var timespans = new List<TimeSpan>(50);
        while (timespans.Count < 50)
        {
            var scheduledTime = DateTime.Now.AddSeconds(0.40);
            Console.WriteLine("Scheduled to run at: {0:hh:mm:ss.FFFF}", scheduledTime);
            var wait = scheduledTime - DateTime.Now + TimeSpan.FromMilliseconds(-50);
            Thread.Sleep((int)Math.Abs(wait.TotalMilliseconds));
            while (DateTime.Now < scheduledTime) ;
            var offset = DateTime.Now - scheduledTime;
            Console.WriteLine("Actual:              {0}", offset);
            timespans.Add(offset);
    
        }
        Console.WriteLine("Average delay: {0}", timespans.Aggregate((a, b) => a + b).TotalMilliseconds / 50);
        Console.Read();
    }
