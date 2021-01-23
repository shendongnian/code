        public static Dictionary<DayOfWeek, int> CountDayOfWeeks(DateTime @from, DateTime to)
        {
            var start = @from.Date;
            var ret = Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>().ToDictionary(x => x, x => 0);
            
            while (start <= to)
            {
                ret[start.DayOfWeek]++;
                start = start.AddDays(1);
            }
            return ret;
        }
