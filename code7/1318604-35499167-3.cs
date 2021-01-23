    public abstract class Period { }
    public class Quarter : Period
    {
        public int Quarter { get; }
        public int Year { get; }
        public Quarter(int year, int quarter)
        {
            if (year < 1800 || year > DateTime.UtcNow.Year)
            {
                throw new ArgumentOutOfRangeException(nameof(year));
            }
            if (quarter < 1 || quarter > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(quarter));
            }
            Year = year;
            Quarter = quarter;
        }
    }
