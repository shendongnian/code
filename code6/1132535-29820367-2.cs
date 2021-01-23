    public static bool TryParseDate(string input, string[] separators, out DateTime date)
    {
        var ci = (CultureInfo) CultureInfo.InvariantCulture.Clone();
            
        foreach (var separator in separators)
        {
            ci.DateTimeFormat.DateSeparator = separator;
            DateTime result;
            if (DateTime.TryParseExact(input, "dd/MM/yyyy", ci, DateTimeStyles.None, 
                                       out date))
                return true;
        }
        date=new DateTime();
        return false;
    }
