        public static IQueryable<Apartment> QueryByPeriod(this IQueryable<Apartment> apartments, DateTime PeriodStart, DateTime PeriodEnd, int StayDuration) {
            var possibleDateRanges = new List<Tuple<DateTime, DateTime>>();
            // list all ranges, so for your example that would be:
            //1.5-10.5
            //2.5-11.5
            //3.5-12.5
            //4.5-13.5
            //5.5-14.5            
            var startDate = PeriodStart;
            while (startDate.AddDays(StayDuration - 1) < PeriodEnd) {
                possibleDateRanges.Add(new Tuple<DateTime, DateTime>(startDate, startDate.AddDays(StayDuration - 1)));
                startDate = startDate.AddDays(1);
            }
            Expression<Func<Apartment, bool>> condition = null;
            foreach (var range in possibleDateRanges) {                
                Expression<Func<Apartment, bool>> rangeCondition = m => m.ApartmentRooms       
                    // find rooms where ALL occupied dates are outside target interval             
                    .Any(g => g.OccupiedDatesBatches.SelectMany(ob => ob.OccupiedDates).All(f => f.Date < range.Item1 || f.Date > range.Item2)
                    );
                // concatenate with OR if necessary
                if (condition == null)
                    condition = rangeCondition;
                else
                    condition = condition.Or(rangeCondition);
            }
            if (condition == null)
                return apartments;
            // note AsExpandable here
            return apartments.AsExpandable().Where(condition);
        }
