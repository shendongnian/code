    for (int i = timers.Count - 1; i >= 0; i--)
    {
        if (timers[i].Tag.ToString()=="mytag")
        {
            timers[i].Enabled = false;
            timers[i].Tick -= OnTimerTick;
            timers.RemoveAt(i);
        }
    }
