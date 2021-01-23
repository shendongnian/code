    //case 1
    TimeSpan StartTime = DateTime.ParseExact("5:00:00 PM", "h:mm:ss tt", CultureInfo.InvariantCulture).TimeOfDay;
    TimeSpan EndTime = DateTime.ParseExact("10:00:00 PM", "h:mm:ss tt", CultureInfo.InvariantCulture).TimeOfDay;
    bool IsNextDay = EndTime < StartTime; //false
    //case 2
    TimeSpan StartTime2 = DateTime.ParseExact("10:00:00 PM", "h:mm:ss tt", CultureInfo.InvariantCulture).TimeOfDay;
    TimeSpan EndTime2 = DateTime.ParseExact("1:00:00 AM", "h:mm:ss tt", CultureInfo.InvariantCulture).TimeOfDay;
    bool IsNextDay2 = EndTime2 < StartTime2; //true
