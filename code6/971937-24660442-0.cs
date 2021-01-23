    public class DateTimeInterval
    {
        /// <summary>
        /// The date and time that the interval starts.
        /// The interval includes this exact value.
        /// </summary>
        public DateTime StartDate { get; private set; }
        /// <summary>
        /// The date and time that the interval is over.
        /// The interval excludes this exact value.
        /// </summary>
        public DateTime EndDate { get; private set; }
        public DateTimeInterval(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
        public IEnumerable<DateTimeInterval> GetSubIntervals(int startingMonth,
                                                             int endingMonth)
        {
            // Determine the possible ranges based on the year of this interval
            // and the months provided
            var ranges = Enumerable.Range(StartDate.Year, EndDate.Year)
                .Select(year => new DateTimeInterval(
                                  new DateTime(year, startingMonth, 1),
                                  new DateTime(
                                    startingMonth > endingMonth ? year + 1 : year,
                                    endingMonth, 1)
                                    .AddMonths(1)));
            // Get the ranges that are overlapping with this interval
            var results = ranges.Where(p => p.StartDate < this.EndDate &&
                                            p.EndDate > this.StartDate)
                                .ToArray();
            // Trim the edges to constrain the results to this interval
            if (results.Length > 0)
            {
                if (results[0].StartDate < this.StartDate)
                {
                    results[0] = new DateTimeInterval(
                        this.StartDate,
                        results[0].EndDate);
                }
                if (results[results.Length - 1].EndDate > this.EndDate)
                {
                    results[results.Length - 1] = new DateTimeInterval(
                        results[results.Length - 1].StartDate,
                        this.EndDate);
                }
            }
            return results;
        }
    }
