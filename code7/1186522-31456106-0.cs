    public string YerSingleQuotesSuck(string incorrectString)
    {
        if(string.IsNullOrWhiteSpace(incorrectString)
            return ""; // or throw, or do whatever
        return incorrectString.Replace("'", "\"");
    }
