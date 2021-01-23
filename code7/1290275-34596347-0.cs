    //Remove all existing trace listeners
    while (Trace.Listeners.Count > 0)
        Trace.Listeners.RemoveAt(0);
    //Add the new one with new file name
    Trace.Listeners.Add(new DelimitedListTraceListener(@"mylogwithdatetime.log"));
