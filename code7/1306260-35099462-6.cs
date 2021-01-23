    public string GetNativeRepresentation(double value)
    {
        var format = CultureInfo.GetCultureInfo("gu-IN").NumberFormat;
        return String.Join("", value.ToString(CultureInfo.InvariantCulture)
                     .Select(x =>
                     {
                         if ("1234567890".Contains(x.ToString()))
                             return format.NativeDigits[x - '0'];
                         else if (x == '-')
                             return format.NegativeSign;
                         else if (x == '.')
                             return format.NumberDecimalSeparator;
                         else
                             return x.ToString();
                     }));
    }
    
