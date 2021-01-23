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
            if (from > to)
            {
                throw new ArgumentException("From cannot be after to");
            }
            TimeSpan duration = TimeSpan.Zero;
            DateTime dayStart = from;
            DateTime dayEnd = from.Date == to.Date ? to : from.Date.AddDays(1);
            while (dayStart < to)
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
                dayEnd = dayStart.Date == to.Date ? to : dayStart.Date.AddDays(1);
            }
            return duration;
        }
        private Dictionary<DayOfWeek, WeekDays> mapping = new Dictionary<DayOfWeek, WeekDays>
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
