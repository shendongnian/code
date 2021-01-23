    ...
    DateTime dt1 = t1.AddMinutes(DateTime.Parse(s1).TimeOfDay.TotalMinutes);
    DateTime dt2 = t2.AddMinutes(DateTime.Parse(s2).TimeOfDay.TotalMinutes);
    if (dt1.TimeOfDay < TimeSpan.FromHours(9))
        dt1 = new DateTime(dt1.Year, dt1.Month, dt1.Day, 9, dt1.Minute, dt1.Second);
    if (dt2.TimeOfDay > TimeSpan.FromHours(18))
        dt2 = new DateTime(dt2.Year, dt2.Month, dt2.Day, 18, dt2.Minute, dt2.Second);
    double days = Math.Floor((dt2 - dt1).TotalDays);
    dt1 += TimeSpan.FromDays(days);
    var hours = (dt2 - dt1).Hours;
    var minutes = (dt2 - dt1).Minutes;
    var totalminutes = (days * 8 * 60 + hours * 60 + minutes);
    // Exact days, hours and minutes worked
    string res = String.Format("{0} days {1} hours {2} minutes", 
        days, 
        hours, 
        minutes);
    
    // Total as days, hours, minutes
    string totRes = String.Format("{0} days {1} hours {2} minutes", 
        totalminutes / 8 / 60, 
        totalminutes / 8, 
        totalminutes);
        
    ...    
