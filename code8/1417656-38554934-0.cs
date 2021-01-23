    public static class TimeController { static DateTime TimeStarted; static TimeSpan TotalTime;
        public static void StartCountDown(TimeSpan totalTime)
        {
            TimeStarted = DateTime.UtcNow;
            TotalTime = totalTime;
        }
        public static TimeSpan TimeLeft
        {
            get
            {
                var result = DateTime.UtcNow - TimeStarted;
                if (result.TotalSeconds <= 0)
                    return TimeSpan.Zero;
                return result;
            }
        }
    }
