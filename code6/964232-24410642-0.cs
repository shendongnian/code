    DateTime ModEndPeriod;
    if (!DateTime.TryParseExact(GetEndPeriod, 
                                format, 
                                CultureInfo.InvariantCulture, 
                                DateTimeStyles.None, 
                                out ModEndPeriod))
    {
        //parsing failed
    }
