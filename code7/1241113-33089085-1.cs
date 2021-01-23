    private static DateTime ParseDate(string date)
    {
       string[] formats =
            {
                "MMMM d\"st\", yyyy",
                "MMMM d\"nd\", yyyy",
                "MMMM d\"rd\", yyyy",
                "MMMM d\"th\", yyyy"
            };
        DateTime dt;
        if (DateTime.TryParseExact(date, formats, new CultureInfo("en-US"),
                              DateTimeStyles.None, out dt))
        {
                return dt;
        }
                
        throw new InvalidOperationException("Invalid Input");
    
    }
