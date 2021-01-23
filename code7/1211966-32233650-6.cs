    public class ScheduledTask
    {
        private ScheduledTask() { }
        public static ScheduledTask CreateTask(TimeSpan start, TimeSpan end, WeekDays days)
        {
            if (start < TimeSpan.Zero || start >= TimeSpan.FromDays(1))
            {
                throw new ArgumentOutOfRangeException("start");
            }
            if (end < TimeSpan.Zero || end >= TimeSpan.FromDays(1))
            {
                throw new ArgumentOutOfRangeException("end");
            }
            if (start > end)
            {
                throw new ArgumentException("End cannot be before Start", "end");
            }
            if ((int)days < 1 || (int)days >= 128)
            {
                throw new ArgumentOutOfRangeException("days");
            }
            return new ScheduledTask { Start = start, End = end, Days = days };
        }
        public WeekDays Days { get; private set; }
        public TimeSpan Start { get; private set; }
        public TimeSpan End { get; private set; }
        public TimeSpan DifferenceMinusTaskTime(DateTime from, DateTime to)
        {
            var actualFrom = from;
            var actualTo = to;
            if (from > to)
            {
                actualFrom = to;
                actualTo = from;
            }
            TimeSpan duration = TimeSpan.Zero;
            DateTime dayStart = actualFrom;
            DateTime dayEnd = actualFrom.Date == actualTo.Date 
                              ? actualTo 
                              : actualFrom.Date.AddDays(1);
            while (dayStart < actualTo)
            {
                duration += dayEnd - dayStart;
                    
                if (Days.HasFlag(mapping[dayStart.DayOfWeek]) && dayStart.TimeOfDay < End)
                {
                    if (dayStart.TimeOfDay < Start)
                    {
                        duration -= End - Start;
                    }
                    else
                    {
                        duration -= End - dayStart.TimeOfDay;
                    }
                }
                dayStart = dayEnd;
                dayEnd = dayStart.Date == actualTo.Date 
                         ? actualTo 
                         : dayStart.Date.AddDays(1);
            }
            return from > to ? TimeSpan.Zero - duration : duration;
        }
        private Dictionary<DayOfWeek, WeekDays> mapping = 
            new Dictionary<DayOfWeek, WeekDays>
            {
                { DayOfWeek.Monday, WeekDays.Monday },
                { DayOfWeek.Tuesday, WeekDays.Tuesday },
                { DayOfWeek.Wednesday, WeekDays.Wednesday },
                { DayOfWeek.Thursday, WeekDays.Thursday },
                { DayOfWeek.Friday, WeekDays.Friday },
                { DayOfWeek.Saturday, WeekDays.Saturday },
                { DayOfWeek.Sunday, WeekDays.Sunday }
            };
    }
