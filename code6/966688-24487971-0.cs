     protected override void OnStart(string[] args)
            {
                updateAutoSMSTimer = new System.Timers.Timer(1 * 60 * 1000);
                updateAutoSMSTimer.Elapsed += new System.Timers.ElapsedEventHandler(Slots);
                updateAutoSMSTimer.Enabled = true;
                updateAutoSMSTimer.AutoReset = true;
                method1();
                updateAutoSMSTimer.Start();
             }
