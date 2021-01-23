    using System;
    using System.Globalization;
    
    class Test
    {    
        public static void Main (string[] args)
        {
            // Note: All tests designed for 2015.
            // January 1st 2015 was a Thursday.
            TryParse("01 Wed"); // False
            TryParse("01 Thu"); // True - 2015-01-01
            TryParse("02 Thu"); // False
            TryParse("02 Fri"); // True - 2015-01-02
        }
        
        private static void TryParse(string text)
        {
            DateTime date;
            bool result = DateTime.TryParseExact(
                text, "dd ddd", CultureInfo.InvariantCulture, 0, out date);
            Console.WriteLine("{0}: {1} {2:yyyy-MM-dd}", text, result, date);
        }
    }
