    private bool IsHex(string input)
    {
        return !String.IsNullOrWhiteSpace(input) && 
               Regex.IsMatch("^[A-F0-9]{1,2}$", input);
    }
