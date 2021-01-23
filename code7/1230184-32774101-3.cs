    public class WeekFactory
        {
            public List<Week> BuildWeeksFromWorkDays(List<DateTime> workDays)
            {
                workDays = workDays.OrderBy(w => w).ToList();
                var startDate = workDays.First();
                if (startDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    startDate = startDate.AddDays(-6);
                }
                else
                {
                    startDate = startDate.AddDays((startDate.DayOfWeek - DayOfWeek.Monday) * -1);
                }
                var weeks = new List<Week>();
                while (startDate <= workDays.Last())
                {
                    var week = new Week(startDate);
                    week.SetWorkDays( workDays.Where(d => d.Date >= startDate && d.Date < startDate.AddDays(7)).ToList());
                    weeks.Add(week);
                    startDate = startDate.AddDays(7);
                }
                return weeks;
            }
        }
