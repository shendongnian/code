    int billingDay = 4;
    DateTime today = DateTime.UtcNow;
    DateTime billing = today.Day >= billingDay
                       ? new DateTime(today.AddMonths(1).Year, today.AddMonths(1).Month, billingDay)
                       : new DateTime(today.Year, today.Month, billingDay);
    TimeSpan left = billing - today;
