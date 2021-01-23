    using System;
    using System.Linq;
    
    class Program
    {
        static void Main(string[] args)
        {
            var year = DateTime.Today.Year;
            for(int month = 1; month <= 12; month++)
            {
                for(int day = 1; day <= DateTime.DaysInMonth(year, month); day++)
                {
                    Console.WriteLine(new DateTime(year, month, day).ToString("dddd MMM d"));
                }  
                Console.WriteLine("Press a key to continue...");
                Console.ReadKey(true);
            }
        }
    }
