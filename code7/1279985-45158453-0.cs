    [Test, Timeout(10000)] // Time out in 10 seconds
    public void Test_MyFunction_DoesNotRunForever()
    {
        DateTime start = DateTime.Now;
        while (true)
        {
            TimeSpan runTime = DateTime.Now - start;
            System.Diagnostics.Debug.WriteLine("Doing stuff for " + runTime.TotalSeconds + " seconds." + (runTime.TotalSeconds > 10 ? " Buggy! :(" : ""));
        }
    }
