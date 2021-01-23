    DateTime time = DateTime.Now;
    DateTime anotherTime = DateTime.Now;
    var allTimes = new HashSet<DateTime>();
    for (int i = 0; i < 6; i++)
    {
        anotherTime = time.AddDays(14);
        time = anotherTime;
        Console.WriteLine(anotherTime.ToLongDateString());
        allTimes.Add(time);
    }
    // or with your example is possible to like this code.
    foreach (var Day in day)
    {
        anotherTime = Day.AddDays(14);
        time = anotherTime;
        Console.WriteLine(anotherTime.ToLongDateString());
        allTimes.Add(time);
    }
