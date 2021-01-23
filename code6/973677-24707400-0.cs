    String inputString="Fri Jul 11 2014 01:30:00 GMT-0700 (Pacific Daylight Time)";
    // we have no need of the parenthetical, get rid of it
    inputString = Regex.Replace(inputString, " \\(.*\\)$", "");
    // exact string format ... 'GMT' is literal
    DateTime theDate = DateTime.ParseExact(inputString,"ddd MMM dd yyyy HH:mm:ss 'GMT'zzz",
        System.Globalization.CultureInfo.InvariantCulture);
