            var dtl = new List<DateTime>();
            dtl.Add(DateTime.Now);
            var DaysOfWeekToInclude = dtl.Where(
                d => d.DayOfWeek == DayOfWeek.Friday || 
                d.DayOfWeek != DayOfWeek.Saturday || 
                d.DayOfWeek == DayOfWeek.Sunday);
            var FirstFilter = DaysOfWeekToInclude.Where(
                p => 
                p.DayOfWeek == DayOfWeek.Friday && p.Hour <= 15);
            var SecondFilter = FirstFilter.Where(
                p => p.DayOfWeek == DayOfWeek.Sunday && p.Hour > 19);
            var filtered = SecondFilter.First();
