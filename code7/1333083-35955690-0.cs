    var startDate = new DateTime(2016, 3, 1);
    var list = new List<DateTime>();
    for(int i = 0; i < DateTime.DaysInMonth(2016, 3); i++) {
        var date = startDate.AddDays(i);
        if (date.DayOfWeek == DayOfWeek.Saturday) list.Add(date);
    }
