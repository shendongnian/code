    class Program
    {
        static void Main(string[] args)
        {
    
            DateTime date;
            if (DateTime.TryParse("01/15/2015", out date))
            {
                var startOfDay = date.Date;
                Console.WriteLine(startOfDay.ToString("s") + "Z");
    
                var endOfDay = date.ToEndOfDay();
                Console.WriteLine(endOfDay.ToString("s") + "Z");
            }
    
            Console.ReadLine();
        }
    }
    
    public static class DateExtensions
    {
        public static DateTime ToEndOfDay(this DateTime date)
        {
            return date.Date.AddDays(1).AddTicks(-1);
        }
    }
