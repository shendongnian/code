    TimeSpan initialTimeSpan = new TimeSpan(0, 4, 2);
    IEnumerable<TimeSpan> spans = Enumerable.Range(0, 5)
        .Select(x => x * 15)
        .Select(x => initialTimeSpan + TimeSpan.FromSeconds(x));
    foreach (TimeSpan span in spans)
    {
        Console.WriteLine(span);
    }
