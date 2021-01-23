    using NodaTime;
    public class LocalDateInterval
    {
        /// <summary>
        /// The date that the interval starts.
        /// The interval includes this exact value.
        /// </summary>
        public LocalDate StartDate { get; private set; }
        /// <summary>
        /// The date that the interval ends.
        /// The interval includes this exact value.
        /// </summary>
        public LocalDate EndDate { get; private set; }
        public LocalDateInterval(LocalDate startDate, LocalDate endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
        public IEnumerable<LocalDateInterval> GetSubIntervals(int startingMonth,
                                                              int endingMonth)
        {
            // Determine the possible ranges based on the year of this interval
            // and the months provided
            var ranges = Enumerable.Range(StartDate.Year,
                                          EndDate.Year - StartDate.Year + 1)
                .Select(year => new LocalDateInterval(
                                  new LocalDate(year, startingMonth, 1),
                                  new LocalDate(
                                    startingMonth > endingMonth ? year + 1 : year,
                                    endingMonth, 1)
                                    .PlusMonths(1).PlusDays(-1)));
            // Get the ranges that are overlapping with this interval
            var results = ranges.Where(p => p.StartDate <= this.EndDate &&
                                            p.EndDate >= this.StartDate)
                                .ToArray();
            // Trim the edges to constrain the results to this interval
            if (results.Length > 0)
            {
                if (results[0].StartDate < this.StartDate)
                {
                    results[0] = new LocalDateInterval(
                        this.StartDate,
                        results[0].EndDate);
                }
                if (results[results.Length - 1].EndDate > this.EndDate)
                {
                    results[results.Length - 1] = new LocalDateInterval(
                        results[results.Length - 1].StartDate,
                        this.EndDate);
                }
            }
            return results;
        }
    }
