    private void AlarmClock_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
            if (speech == "set the alarm")
            { AlarmTime = "set"; Alexis.SpeakAsync("What time?"); }
            if (AlarmTime == "set")
            {
                foreach (string time in AlarmAM)
                {
                    if (speech == time)
                    { AlarmTimer.Enabled = true; Alexis.SpeakAsync("Alarm set for " + time); Settings.Default.Alarm = time; }
                }
                foreach (string time in AlarmPM)
                {
                    if (speech == time)
                    { AlarmTimer.Enabled = true; Alexis.SpeakAsync("Alarm set for " + time); Settings.Default.Alarm = time; }
                }
            }
            if (speech == "clear the alarm")
            { Settings.Default.Alarm = String.Empty; AlarmTimer.Enabled = false; Alexis.SpeakAsync("The alarm is no longer set"); }
            if (speech == "what time is the alarm")
            { Alexis.SpeakAsync(Settings.Default.Alarm); }
        }
