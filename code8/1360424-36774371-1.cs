    public Tuple<bool, string> stringFormatCheck(string input)
    {            
        if (Regex.IsMatch(input, @"^[A-Za-z]{2}[0-9]{5}[A-Za-z]$"))
            return Tuple.Create(true, "String is Fine");
        else
            return Tuple.Create(false, "String Format is incorrect");
    }
