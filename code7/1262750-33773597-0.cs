    DateTime thisTime;
    if (DateTime.TryParseExact("Inputted Date", "Date Format", 
                    System.Globalization.CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out thisTime))
    {
        //success code
    }
    else
    {
        //failure code
    }
