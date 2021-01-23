    class Program
    {
        private static readonly HashSet<DateTime> Holidays = new HashSet<DateTime>();
        private static bool IsHoliday(DateTime date)
        {
            return Holidays.Contains(date);
        }
        private static bool IsWeekEnd(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday
                || date.DayOfWeek == DayOfWeek.Sunday;
        }
        private static DateTime GetNextWorkingDay(DateTime date)
        {
            do
            {
                date = date.AddDays(1);
            } while (IsHoliday(date) || IsWeekEnd(date));
            return date;
        }
        static void Main(string[] args)
        {
            Holidays.Add(new DateTime(DateTime.Now.Year, 1, 1));
            Holidays.Add(new DateTime(DateTime.Now.Year, 1, 5));
            Holidays.Add(new DateTime(DateTime.Now.Year, 3, 10));
            Holidays.Add(new DateTime(DateTime.Now.Year, 12, 25));
            var dt = GetNextWorkingDay(DateTime.Parse(@"2015-10-31"));
            Console.WriteLine(dt);
            Console.ReadKey();
        }
    }
