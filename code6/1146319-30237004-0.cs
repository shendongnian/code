    var febComparer = Period.CreateComparer(new LocalDate(2015, 2, 1).AtMidnight());
    var marchComparer = Period.CreateComparer(new LocalDate(2015, 3, 1).AtMidnight());
    var oneMonth = Period.FromMonths(1);
    var twentyNineDays = Period.FromDays(29);
    // -1: Feb 1st + 1 month is earlier than Feb 1st + 29 days
    Console.WriteLine(febComparer.Compare(oneMonth, twentyNineDays));
    // 1: March 1st + 1 month is later than March 1st + 29 days
    Console.WriteLine(marchComparer.Compare(oneMonth, twentyNineDays));
