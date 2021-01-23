    public class ServerTime
    {
        public static DateTime Now
        {
            get
            {
                if (baseTime != null)
                    return baseTime.Add(swatch.Elapsed);
                else
                    return DateTime.Now;
            }
            set
            {
                baseTime = value;
                swatch.Reset();
                swatch.Start();
            }
        }
        private static DateTime baseTime;
        private static Stopwatch swatch = new Stopwatch();
          
    }
