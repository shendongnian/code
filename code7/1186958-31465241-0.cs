    [Flags]
    public enum WeekDays
    {
        Monday = 1,
        Tuesday = 2,
        Wednesday = 4,
        Thursday = 8,
        Friday = 16,
        Saturday = 32,
        Sunday = 64
    }
    public class Week
    {
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        private static readonly WeekDays[] WeekDaysLookup = new[]
        {
            WeekDays.Monday, WeekDays.Tuesday, WeekDays.Wednesday, WeekDays.Thursday, WeekDays.Friday, WeekDays.Saturday, WeekDays.Sunday
        };
        public static explicit operator WeekDays(Week week)
        {
            var points = new[]
            {
                week.Monday,
                week.Tuesday,
                week.Wednesday,
                week.Thursday,
                week.Friday,
                week.Saturday,
                week.Sunday
            };
            WeekDays weekDays = 0;
            for (var i = 0; i < points.Length; i++)
            {
                if (points[i])
                {
                    weekDays = weekDays | WeekDaysLookup[i];
                }
            }
            return weekDays;
        }
        public static explicit operator Week(WeekDays weekDays)
        {
            return new Week
            {
                Monday = weekDays.HasFlag(WeekDays.Monday),
                Tuesday = weekDays.HasFlag(WeekDays.Tuesday),
                Wednesday = weekDays.HasFlag(WeekDays.Wednesday),
                Thursday = weekDays.HasFlag(WeekDays.Thursday),
                Friday = weekDays.HasFlag(WeekDays.Friday),
                Saturday = weekDays.HasFlag(WeekDays.Saturday),
                Sunday = weekDays.HasFlag(WeekDays.Sunday)
            };
        }
        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3},{4},{5},{6}", Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday);
        }
    }
