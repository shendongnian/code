    public class YearTimeframe : Timeframe
    {
        // WARNING: 'YearTimeframe.Year' hides inherited member 'Timeframe.Year(int)'.
        // (a public property w/ private readonly backing field has same problem)
        public readonly int Year;
        public YearTimeframe(int year)
            : base(
                new DateTime(year, 1, 1),
                new DateTime(year, 12, 31, 23, 59, 59))
            {
                this.Year = year;
                Timeframe.Year();
            }
        }
    }
