    bool isWeekDay == DateTime.Today.DayOfWeek > DayOfWeek.Sunday 
        && DateTime.Today.DayOfWeek < DayOfWeek.Saturday;
    if (isWeekDay) {
        Console.WriteLine("It is a week day");
    }
    else {
        Console.WriteLine("it is a weekend");
    }
