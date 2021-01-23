    TimeSpan TotalTime = TimeSpan.Parse("10:00:00");
            
    if (TotalTime != null)
    {
        var ticks = ((TotalTime.Ticks * 80) / 100);
        TimeSpan Percentage = new TimeSpan(ticks);
        Console.WriteLine(Percentage);  // 8 hours
    }
