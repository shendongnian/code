    //here you can define more that one format to parce
    string[] formats = { "dd-MM-yyyy"};
    DateTime resultDate = new DateTime();
    if (DateTime.TryParseExact(Request["date"], formats, System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.None, out resultDate))
    {
        //if everything good you will have your date in resultDate variable
        date = resultDate.ToString("MM-dd-yyyy HH:mm:ss"); 
    }
    else
    { 
        //here the logic if parce fails
    }
