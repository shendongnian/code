    DateTime time = DateTime.Now;
    DateTime anotherTime = DateTime.Now;
    for (int i = 0; i < 6; i++)
    {
        anotherTime = time.AddDays(14);
        time = anotherTime;
        Console.WriteLine(anotherTime.ToLongDateString());
    }
