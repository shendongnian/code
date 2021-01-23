    class Program
        {
            [Flags]
            public enum WeekDays
            {
    
                Monday = 1,
                Tuesday = 2,
                Wednesday = 4,
                Thursday = 8,
                Friday = 16,
                Saturday = 32,
                Sunday = 64
            }
    
            private static string result;
    
            static void Main()
            {
                var wd = new WeekDays();
                Console.WriteLine(wd.HasFlag(WeekDays.Monday));
    
                wd = WeekDays.Monday;
    
                Console.WriteLine(wd.HasFlag(WeekDays.Monday));
    
                bool is_defined = Enum.IsDefined(typeof(WeekDays), "Monday");
                Console.WriteLine(is_defined);
                bool is_not_defined = Enum.IsDefined(typeof(WeekDays), "Mondays");
                Console.WriteLine(is_not_defined);
                Console.ReadLine();
            }
        }
