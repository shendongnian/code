     foreach (Timer timer in timers)
        {
            if (timer.Tag.ToString()=="mytag")
            {
                timer.Enabled = false;
        
                timer.Tick -= OnTimerTick;
                timers.Remove(timer);
            }
        }
