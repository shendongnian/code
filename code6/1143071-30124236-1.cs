    TimeRange range = new TimeRange(DateTime.Today, DateTime.Now);
    Console.WriteLine("Range is {0}", range.ToString());
    for (int i = 0; i < 24; i++)
    {
        Console.WriteLine("Time {0:00}:00 is in range? {1}", i, range.IsDateInRange(DateTime.Today.AddHours(i)));
    }
