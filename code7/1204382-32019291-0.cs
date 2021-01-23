        DateTime nextRestart = GetRestartTime();
        AppConsole.Log("Restarter timer started", ConsoleColor.Green);
        Timer t = new Timer();
        t.Tick += (o, e) =>
        {
            TimeSpan timeLeft = nextRestart.Subtract(DateTime.Now);
            if (timeLeft.CompareTo(TimeSpan.Zero) < 0)
            {
                t.Stop();
                DoRestart();
            }
            else
            {
                SendMessage(String.Format("Time until next restart: {0} hours, {1} minutes, {2} seconds.",
                    timeLeft.Hours, timeLeft.Minutes, timeLeft.Seconds));
                if (timeLeft.CompareTo(TimeSpan.FromMinutes(5)) < 0)
                    t.Interval = 150 * 60 * 1000; // ms
                else if (timeLeft.CompareTo(TimeSpan.FromMinutes(10)) < 0)
                    t.Interval = 300 * 60 * 1000; // ms
            }
        };
        t.Interval = (nextRestart - DateTime.Now).Milliseconds;
        t.Start();
