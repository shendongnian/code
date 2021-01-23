    static IEnumerable<DateTime> extractDates(string inputString)
    {
        foreach (var item in inputString.Split(new string[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries))
        {
            DateTime dt;
            if(DateTime.TryParseExact(item, 
                                       "dd/MM/yyyy HH:mm",
                                       System.Globalization.CultureInfo.InvariantCulture,
                                       System.Globalization.DateTimeStyles.None, 
                                       out dt))
                yield return dt;
        }
    }
