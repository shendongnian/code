    public static bool IpAddressMatchUserInput(String userInput, String ipAddressFromList)
    {
        Regex rg = new Regex(userInput.Replace("*", @"\d{1,3}").Replace(".", @"\."));
    
        return rg.IsMatch(ipAddressFromList);
    }
