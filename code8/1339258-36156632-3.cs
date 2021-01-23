    static void DoStuff(string s)
    {
        // change to a value > 0.5 as well to ensure everything works
        Thread.Sleep(TimeSpan.FromSeconds(0.1)); 
        Console.WriteLine(s);
    }
    static void Handle(List<string> models)
    {
        while (true)
        {
            // we want to run it again in 0.5 seconds.
            DateTime start = DateTime.UtcNow.AddSeconds(0.5);
            Parallel.ForEach(models, (a) => DoStuff(a));
            DateTime current = DateTime.UtcNow;
            if (current < start)
            {
                Thread.Sleep(start.Subtract(current));
            }
        }
    }
    static void Main(string[] args)
    {
        List<string> models = new List<string>();
        for (int i = 0; i < 10; ++i)
        {
            models.Add(i.ToString());
        }
        Handle(models);
    }
