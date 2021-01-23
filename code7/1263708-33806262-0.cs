    public static decimal StringToDecimal(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            // log error, throw exception, or just return a default value if acceptable
        }
        decimal d;
        if (decimal.TryParse(s, out d))
        {
            return d;
        }
        else 
        {
            // appropriately log errors and/or throw a more meaningful exception
        }
    }
