    private bool IsHex(string input, int maxDigits = 2)
    {
        return !String.IsNullOrWhiteSpace(input) && 
               maxDigits > 0 &&
               Regex.IsMatch(String.Format("^[A-F0-9]{{1,{0}}}$", maxDigits), input);
    }
