    DateTime today = DateTime.Today;
    DateTime payDay;
    if(today.Day <= 15)
        payDay = new DateTime(today.Year, today.Month, 15);
    else
        payDay = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
