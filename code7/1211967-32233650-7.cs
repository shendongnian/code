    var task = ScheduledTask.CreateTask(
        TimeSpan.Zero,
        TimeSpan.FromHours(6),
        WeekDays.Monday | WeekDays.Tuesday | WeekDays.Wednesday);
    Console.WriteLine(
        task.DifferenceMinusTaskTime(
            new DateTime(2015, 8, 24), 
            new DateTime(2015, 8, 27)));
