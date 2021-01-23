    public class PeriodFactory
        {
            public List<Period> GetPeriodsOfLikeWeeks(List<Week> weeks)
            {
                var periods = new List<Period>();
                Period currentPeriod = null;
                foreach (var week in weeks)
                {
                    if (currentPeriod == null)
                    {
                        currentPeriod = new Period(week);
                        periods.Add(currentPeriod);
                        continue;
                    }
                    if (!currentPeriod.AddWeek(week))
                    {
                        currentPeriod = new Period(week);
                        periods.Add(currentPeriod);
                    }
                }
                return periods;
            }
        }
