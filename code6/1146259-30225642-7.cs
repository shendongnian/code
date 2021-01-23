    public static void Main(params string[] args)
    {
        var periodic = new PeriodicTimerTask(TimeSpan.FromSeconds(1), cancel => {
            int n = 0;
            Console.Write("Tick ...");
            while (!cancel.IsCancellationRequested && n < 100000)
            {
                n++;
            }
            Console.WriteLine(" completed.");
        });
        periodic.Start();
        Console.WriteLine("Press <ENTER> to stop");
        Console.ReadLine();
        Console.WriteLine("Stopping");
        periodic.Dispose();
        Console.WriteLine("Stopped");
    }
