    var timersToRemove = new List<Timer>();
    foreach (Timer timer in timers)
        {
            if (timer.Tag.ToString()=="mytag")
            {
                timer.Enabled = false;
        
                timer.Tick -= OnTimerTick;
                timersToRemove.Add(timer);
            }
        }
    foreach(var timer in timersToRemove)
       timers.Remove(timer);
    // Clear the list
    timersToRemove.Clear();
