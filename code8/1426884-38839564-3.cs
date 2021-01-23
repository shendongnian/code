    using System;
    
    namespace Test
    {
        public class Program
        {
            public static void Main()
            {
                DateTime begin = new DateTime(2006, 10, 24);
                while (begin < new DateTime(2006, 12, 25))
                {
                    Console.WriteLine(begin + " - " + begin.IsDaylightSavingTime());
                    begin = begin.AddDays(1);
                }
            }
        }
    }
