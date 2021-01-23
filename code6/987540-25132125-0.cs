    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                DateTime newData;
                TimeSpan newSpan;
                DateTime.TryParseExact("00:20:00", "%h:%m:%s",
                       CultureInfo.DefaultThreadCurrentCulture, DateTimeStyles.None, out newData);
                Console.WriteLine(newData);
                // 8/5/2014 12:20:00 AM
                TimeSpan.TryParseExact("00:20:00", @"hh\:mm\:ss",
                       CultureInfo.DefaultThreadCurrentCulture, TimeSpanStyles.None, out newSpan);
                Console.WriteLine(newSpan);
                // 00:20:00
                Console.WriteLine(newSpan.Hours);
                // 0 
                Console.WriteLine(newSpan.TotalHours);
                // 0.33~
                Console.ReadLine();
            }
        }
    }
