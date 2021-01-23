        public static DateTime ThirdMonday(DateTime thirdMonday, DateTime month) {
                var mondayDay = (from day in Enumerable.Range(1, 31)
                                 where new DateTime(thirdMonday.Year, month.Month, day).DayOfWeek == DayOfWeek.Monday
                                 select day).ElementAt(2);
                var result = new DateTime(thirdMonday.Year, thirdMonday.Month, mondayDay);
                return result;
            }
        static void Main(string[] args)
        {
            var result = ThirdMonday(DateTime.Now, new DateTime(2016, 2, 1)); //pass February as the month
            Console.WriteLine(result);
            Console.Read();
        }
