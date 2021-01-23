    Stopwatch stopWatch;
    TextBoxEnterHandler(...)
    {
        stopwatch.ReStart();
    }
    TextBoxExitHandler(...)
    {
        stopwatch.Stop();
    }
    TextChangedHandler(...)
    {
        if (stopWatch.ElapsedMiliseconds < threshHold)
        {
            stopwatch.Restart();
            return;
        }
             
        {
           //Update code
        }
        stopwatch.ReStart()
    }
