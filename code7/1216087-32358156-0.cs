    var startDate = DateTime.Now;// put here your actual start date
    for (int i = 0; i < 5;)      // mention, how many days you want to add instead of 5
    {
        if (startDate.DayOfWeek == DayOfWeek.Saturday || startDate.DayOfWeek == DayOfWeek.Sunday)
        {
            continue;
        }
        startDate = startDate.AddDays(i);
        i++;
    }
    var finalDate = startDate;
