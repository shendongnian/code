    DateTime dt;
    string[] formats = { "yyyy-mmm-dd"};
    if (!DateTime.TryParseExact(dateValue, formats, 
                    System.Globalization.CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out dt))
    {
        //your condition fail code goes here
        return false;
    }
    else
    {
        //success code
    }
