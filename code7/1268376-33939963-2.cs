    public static bool IsValidDecimal()
    {
        string input = "132456789"
        Match m = Regex.Match(input, @"^-?\d*\.?\d+");
        return m.Success && m.Value != "";
    }
