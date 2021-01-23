    public string concatStrings(string value, string value2)
    {
       string conststr= "IHaveADream";
        string input = "ByeBye";
        string result = "";
    
        for(int i = 0; i < conststr.Length && i < input.Length) result += conststr[i] + input[i];
        return result;
    }
