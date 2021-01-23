    public static void Main()
    {
        System.Timers.Timer timer = new System.Timers.Timer();
        timer.Elapsed += (source, srgs) =>
        {
            foreach (Process process in Process.GetProcessesByName("vlc"))
            {
                process.Kill();
                process.WaitForExit();
                timer.Start(); //Restart again
            }
        };
        timer.Interval = 10000; //Run every 10 seconds
        timer.AutoReset = false; //This causes the timer to run only once
        timer.Enabled = true;
        timer.Start();
        Console.WriteLine("Press any key to exit");
        Console.ReadLine();
    }
