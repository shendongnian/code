    var task = ScheduledTask.CreateTask(
        new TimeSpan(0),
        new TimeSpan(6, 0, 0),
        WeekDays.Monday | WeekDays.Tuesday | WeekDays.Wednesday);
    Console.WriteLine(task.DifferenceMinusTaskTime(new DateTime(2015, 8, 24), new DateTime(2015, 8, 27)));
