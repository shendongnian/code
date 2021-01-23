    public static bool IpAddressMatchUserInput(String userInput, String ipAddressFromList)
    {
        Regex rg = new Regex(userInput.Replace("*", "[0-255]"));
    
        return rg.IsMatch(ipAddressFromList);
    }
