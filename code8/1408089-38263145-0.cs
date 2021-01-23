    public static bool IpAddressMatchUserInput(string userInput, string ipAddressFromList)
    {
        // escape the user input. If user input contains e.g. an unescaped 
        // single backslash we might get an ArgumentException when not escaping
        var escapedInput = Regex.Escape(userInput);
        // replace the wildcard '*' with a regex pattern matching 1 to 3 digits
        var inputWithWildcardsReplaced = escapedInput.Replace("\\*", @"\d{1,3}");
        // require the user input to match at the beginning of the provided IP address
        var pattern = new Regex("^" + inputWithWildcardsReplaced);
        return pattern.IsMatch(ipAddressFromList);
    }
