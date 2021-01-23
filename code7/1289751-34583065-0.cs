    var dateWithMilliseconds = new DateTime(2016, 1, 4, 1, 0, 0, 100);  
    int beforeConversion = dateWithMilliseconds.Millisecond;  // 100
    var dateAsString = dateWithMilliseconds.ToString();       // 04-01-16 1:00:00 AM (or similar, depends on culture)
    var dateFromString = Convert.ToDateTime(dateAsString);
    int afterConversion = dateFromString.Millisecond;         // 0
