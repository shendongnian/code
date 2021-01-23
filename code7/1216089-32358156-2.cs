    var startDate = DateTime.Now;  // Put your actual start date here
    for (int i = 0; i < 5;)        // Put number of days to add instead of 5
    {
        startDate = startDate.AddDays(1);
        if (startDate.DayOfWeek == DayOfWeek.Saturday || startDate.DayOfWeek == DayOfWeek.Sunday)
        {              
            continue;
        }
        i++;
    }
    var finalDate = startDate;
