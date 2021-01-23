    var task = ScheduledTask.CreateTask(
        TimeSpan.FromHours(2),
        TimeSpan.FromHours(8),
        WeekDays.Monday | WeekDays.Tuesday | WeekDays.Wednesday);
    Console.WriteLine(
        task.DifferenceMinusTaskTime(
            new DateTime(2015, 8, 24), 
            new DateTime(2015, 8, 27))); // 2 days 6 hours
    Console.WriteLine(
        task.DifferenceMinusTaskTime(
           new DateTime(2015, 8, 27), 
           new DateTime(2015, 8, 24))); // -2 days 6 hours
    Console.WriteLine(
        task.DifferenceMinusTaskTime(
            new DateTime(2015, 8, 28), 
            new DateTime(2015, 8, 29))); // 1 day
    Console.WriteLine(
        task.DifferenceMinusTaskTime(
            new DateTime(2015, 8, 24), 
            new DateTime(2015, 8, 24, 10, 0, 0))); // 4 hours
    Console.WriteLine(
        task.DifferenceMinusTaskTime(
            new DateTime(2015, 8, 24), 
            new DateTime(2015, 8, 24, 4, 0, 0))); // 2 hours
    Console.WriteLine(
        task.DifferenceMinusTaskTime(
           new DateTime(2015, 8, 24, 4, 0, 0), 
           new DateTime(2015, 8, 24, 6, 0, 0))); // 0 hours
    Console.WriteLine(
        task.DifferenceMinusTaskTime(
            new DateTime(2015, 8, 24, 4, 0, 0), 
            new DateTime(2015, 8, 24, 10, 0, 0))); // 2 hours
    Console.WriteLine(
        task.DifferenceMinusTaskTime(
            new DateTime(2015, 8, 24, 10, 0, 0), 
            new DateTime(2015, 8, 24, 14, 0, 0))); // 4 hours
