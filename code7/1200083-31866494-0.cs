    int serviceday;
    int servicehour;
    int serviceminute;
    Int32.TryParse(ServiceDay, out serviceday);
    Int32.TryParse(ServiceHour, out servicehour);
    Int32.TryParse(ServiceMinute, out serviceminute);
    DateTime finalDateTime = serviceEntry.ServiceDateTime
                            .AddDays(serviceday)
                            .AddHours(servicehour)
                            .AddMinutes(serviceminute);
