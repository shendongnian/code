    public class TimeRange
    {
        private double _begin;              // total ms from 00:00
        private double _end;                // total ms from 00:00
    
        /// <param name="begin"> begin time (for example 8:30:15am) </param>
        /// <param name="end"> begin time (for example 12pm) </param>
        public TimeRange(DateTime begin, DateTime end)
        {
            _begin = begin.TimeOfDay.TotalMilliseconds;
            _end = end.TimeOfDay.TotalMilliseconds;
        }
    
        /// <summary>
        /// check time in range
        /// </summary>
        /// <param name="time"> time </param>
        /// <returns></returns>
        public bool IsDateInRange(DateTime time)
        {
            double value = time.TimeOfDay.TotalMilliseconds;
            return _end > _begin ? (value >= _begin && value <= _end) : (value >= _end && value <= _begin);
        }
    
        public override string ToString()
        {
            DateTime today = DateTime.Today;
            return string.Format(_end > _begin ? "{0}-{1}" : "{1}-{0}",
                (today + TimeSpan.FromMilliseconds(_begin)).ToString("HH:mm"),
                (today + TimeSpan.FromMilliseconds(_end)).ToString("HH:mm"));
        }
    }
