    DateTime dt = new DateTime(int.Parse(arabic[0]),
                               int.Parse(arabic[1]),
                               int.Parse(arabic[2]),
                               new System.Globalization.HijriCalendar());
    var pc = new System.Globalization.PersianCalendar();
    var result = pc.ToDateTime(dt.Year, dt.Month, dt.Day, 
                                dt.Hour, dt.Minute, 0, 0); 
