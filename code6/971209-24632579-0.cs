    string inputdate = "2:56:30 8/7/2014";
    DateTime dt;
    System.Globalization.CultureInfo enUS = new System.Globalization.CultureInfo("en-US");
    
    if (DateTime.TryParseExact(inputdate, "H:m:s d/M/yyyy", // hours:minutes:seconds day/month/year
    	enUS, System.Globalization.DateTimeStyles.None, out dt))
    {
      // 'dt' contains the parsed date: "8-7-2014 02:56:30"
      DateTime rounded = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, 0, 0);
      if (dt.Minute > 0 || dt.Second > 0) // or just check dt.Minute >= 30 for regular rounding
        rounded = rounded.AddHours(1);
    	
      // 'rounded' now contains the date rounded up: "8-7-2014 03:00:00"
    }
    else
    {
      // not a correct date
    }
