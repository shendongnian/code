    static void Main(string[] args)
    {
       for (int i = 0; i < 1000; i++)
       {
           TimeSpan delay = TimeSpan.FromSeconds(1);
           if (i % 2 == 0) delay = TimeSpan.FromDays(1);
           System.Timers.Timer timer = new System.Timers.Timer();
           timer.AutoReset = false;
           timer.Interval = delay.TotalMilliseconds;
           timer.Elapsed += async (x, y) =>
           {
                MyObject o = new MyObject();
                await o.Run();
           };
            timer.Start();
       }
       Console.ReadKey();
    }
