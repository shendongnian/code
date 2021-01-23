       public void ScheduleService()
        {
            try
            {
                // Only create timer once
                if (Schedular != null)
                    Schedular = new Timer(new TimerCallback(SchedularCallback));
                // Use proper way to get setting
                string mode = Properties.Settings.Default.Mode.ToUpper();
                ...
                if (mode == "INTERVAL")
                {
                    // Use proper way to get settings
                    int intervalMinutes = Properties.Settings.Default.IntervalMinutes;
                    ...
