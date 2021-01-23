    DateTime parsed;
    if (DateTime.TryParseExact(
       dateString, 
       format, 
       System.Globalization.CultureInfo.InvariantCulture, 
       DateTimeStyles.None, 
       out parsed) 
    {
       // parsing was successful
    }
    else
    {
       // parsing failed
    }
