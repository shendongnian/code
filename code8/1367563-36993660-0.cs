    private static DateTime startTime;
    private const string START_TIME_FILENAME = "./your/path.txt"
    public static void StartStopWatch()
    {
        // Persist this variable until the app is closed
        startTime = DateTime.Now;
        //Persist this variable until it is overwritten
        System.IO.File.WriteAllText(START_TIME_FILENAME, startTime.ToString());
    }
    // Get the difference in time since you started the stopwatch and now
    public static TimeSpan Elapsed()
    {
        if (startTime == null)
        {
            startTime = GetStartTime();
        }
        return DateTime.Now - startTime;
    }
    // Call this method to get the start time after the app has been closed
    private static DateTime GetStartTime()
    {
        return Convert.ToDateTime(System.IO.File.ReadAllText(START_TIME_FILENAME));
    }
