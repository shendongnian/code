    class Program
    {
        static void Main(string[] args)
        {
            DateTime endDate = MoscowTime(DateTime.Parse("2015-09-10 22:20:41"));
            TimeSpan difference = endDate - MoscowTime(DateTime.Now);
            Console.WriteLine(difference.Hours + ":" + difference.Minutes + ":" + difference.Seconds);
            Console.ReadLine();
        }
        public static DateTime MoscowTime(DateTime time)
        {
            TimeZone zone = TimeZone.CurrentTimeZone;
            DateTime universal = zone.ToUniversalTime(time);
            return universal.AddHours(3);
        }
    }
