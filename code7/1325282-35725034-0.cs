    var timer = new System.Timers.Timer(4000);
        timer.Enabled = true;
        timer.Elapsed += (object sender, System.Timers.ElapsedEventArgs e) =>
        {
            timer.Enabled = false;
            wrtiteToFile.Suspend();
            SendEmail();
            wrtiteToFile.Resume();
            timer.Enabled = true;
        };
