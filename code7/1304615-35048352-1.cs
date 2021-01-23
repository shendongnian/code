    public static void Main()
    {
        System.Timers.Timer timer = new System.Timers.Timer();
        timer.Elapsed += (source, srgs) =>
        {
            foreach (Process process in Process.GetProcessesByName("vlc"))
            {
                process.Kill();
                process.WaitForExit();
            }
            //Start again. 
            //This makes sure that we wait 10 seconds after
            //we are done killing the processes
            timer.Start();
        };
        //Run every 10 seconds
        timer.Interval = 10000; 
        //This causes the timer to run only once
        //But will be restarted after processing. See comments above
        timer.AutoReset = false;
        timer.Start();
        Console.WriteLine("Press any key to exit");
        Console.ReadLine();
    }
