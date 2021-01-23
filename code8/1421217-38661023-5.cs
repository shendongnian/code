    public static class Extensions
    {
        public static TimeSpan Age(this DateTime dt)
        {
            return (DateTime.Now - dt);
        }
    
        public static int Years(this TimeSpan ts)
        {
            return (int)((double)ts.Days / 365.2425);
        }
    }
