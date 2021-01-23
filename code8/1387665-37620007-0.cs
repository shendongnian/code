    public static TimeSpan Parse(string value) {
         
        if (value.Length == 1)
        {
            value = value.PadLeft(2, '0');
            value = value.PadRight(4, '0');
        }
        else if (value.Length == 2)
        {
            value = value.PadRight(4, '0');
        }
        else if(value.Length == 3)
        {
            value = value.PadLeft(4, '0');
        }
        return TimeSpan.ParseExact(value, new string[] { "%h\\:mm", "%hmm", "hmm", "hhmm" }, CultureInfo.InvariantCulture);//Exception! None format works.
    }
