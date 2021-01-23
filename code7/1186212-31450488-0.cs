    String dtFormat = "MM/dd/yyyy h:mm:ss tt";
    String dtString = "02/01/2015 10:01:56 AM";
    DateTime dtObject = DateTime.ParseExact(dtString, dtFormat, System.Globalization.CultureInfo.InvariantCulture);
    if (dtObject.AddHours(1) >= DateTime.Now)
    {
        //Greater
    }
    else
    {
        // Smaller
    }
