    static void Main(string[] args)
    {        
        var year = DateTime.Today.Year;
        foreach (var month in Enumerable.Range(1, 12))
        {
            var day = new DateTime(year, month, 1);
            while (day.Month == month)
            {
                Console.WriteLine(day.ToString("dddd MMM d"));
                day = day.AddDays(1);
            }
            Console.WriteLine("Press a key to continue...");
            Console.ReadKey(true);
        }
    }
