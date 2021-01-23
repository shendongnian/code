    private bool IsHex(string input)
    {
        return !String.IsNullOrWhiteSpace(input) && 
               Regex.IsMatch("[A-F0-9]{0,2}", input);
    }
