        public static Dictionary<DayOfWeek, int> CountDayOfWeeks(DateTime @from, DateTime to)
        {
            var days = new List<DateTime>((int) to.Subtract(@from).TotalDays);
            var start = @from.Date;
            while (start <= to)
            {
                days.Add(start);
                start = start.AddDays(1);
            }
            var ret = Enum.GetValues(typeof (DayOfWeek)).Cast<DayOfWeek>().ToDictionary(x => x, x => 0);
            var dayOfWeeks = from d in days
                group d by d.DayOfWeek
                into dowg
                select new {DayOfWeek = dowg.Key, Count = dowg.Count()};
            foreach (var day in dayOfWeeks)
            {
                ret[day.DayOfWeek] = day.Count;
            }
            return ret;
        }
