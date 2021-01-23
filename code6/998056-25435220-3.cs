    DateTime dt;
    if (DateTime.TryParseExact("20140404",
        "yyyyMMdd",
        CultureInfo.InvariantCulture,
        DateTimeStyles.None,
        out dt))
    {
        //parsing successfull
    }
    else
    {
        //parsing failed
    }
