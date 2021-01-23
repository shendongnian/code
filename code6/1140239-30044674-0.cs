    class Program
    {
        class DateRange
        {
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
        }
        static void Main(string[] args)
        {
            DateRange vacation = new DateRange();
            vacation.Start = new DateTime(2014, 3, 19);
            vacation.End = new DateTime(2014, 4, 5);
            // Assuming April 5 represents the last day of vacation, let's
            // add one to it, to show that his vacation actually ends on the
            // following day.
            vacation.End = vacation.End.AddDays(1);
            DateRange currentMonth = new DateRange();
            currentMonth.Start = new DateTime(vacation.Start.Year, vacation.Start.Month, 1);
            currentMonth.End = currentMonth.Start.AddMonths(1);
            while (currentMonth.Start < vacation.End)
            {
                Console.WriteLine("Vacation days in {0}: \t{1} days",
                    currentMonth.Start.ToString("MMMM"),
                    IntersectDates(currentMonth, vacation));
                currentMonth.Start = currentMonth.Start.AddMonths(1);
                currentMonth.End = currentMonth.End.AddMonths(1);
            }
        }
        // Returns the number of days represented by the intersection of the two
        // date ranges.
        static int IntersectDates(DateRange dateRange1, DateRange dateRange2)
        {
            DateTime startOfIntersection = MaxDate(dateRange1.Start, dateRange2.Start);
            DateTime endOfIntersection = MinDate(dateRange1.End, dateRange2.End);
            return (startOfIntersection < endOfIntersection) ?
                (int)(endOfIntersection - startOfIntersection).TotalDays :
                0;
        }
        static DateTime MinDate(DateTime d1, DateTime d2)
        {
            return (d1 < d2) ? d1 : d2;
        }
        static DateTime MaxDate(DateTime d1, DateTime d2)
        {
            return (d1 > d2) ? d1 : d2;
        }
    }
