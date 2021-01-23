    public static string Acronym(string input)
    {
        string result = string.Empty;
        char last = ' ';
    
        foreach(var c in input)
        {
            if(char.IsWhiteSpace(last))
            {
                result += c;              
            }
            last = c;
        }
    
        return result.ToUpper();
    }
