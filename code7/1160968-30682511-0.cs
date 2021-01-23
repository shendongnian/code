    public class TimeSpanCustom
    {
        TimeSpan ts;
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public int Milliseconds { get; set; }
        public TimeSpanCustom(int days, int hours, int minutes, int seconds, int milliseconds)
        {
            this.Hours = hours;
            this.Minutes = minutes;
            this.Seconds = seconds;
            this.Milliseconds = milliseconds;
            ts = new TimeSpan(days, hours, minutes, seconds, milliseconds);
        }
        public TimeSpanCustom Subtract(TimeSpanCustom ts)
        {
            TimeSpan minuend = new TimeSpan(0, ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            TimeSpan result = this.ts.Subtract(minuend);
            return new TimeSpanCustom(0, result.Hours, result.Minutes, result.Seconds, result.Milliseconds);
        }
    }
