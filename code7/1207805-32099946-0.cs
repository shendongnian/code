    DateTime startTime = DateTime.Now;
    bool running = true;
    DateTime? lastRunTime = null;
    while (running)
    {
        if (!lastRunTime.HasValue)
        {
            if ((DateTime.Now - startTime).Minutes >= Program.genTimer)
            {
                i = 1;
                lastRunTime = DateTime.Now;
            }
        }
        else if ((DateTime.Now - lastRunTime.Value).Minutes >= Program.genTimer)
        {
                //doestuff
        }
    }
