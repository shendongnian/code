    string ConvertDashToCamelCase(string input)
    {
        string[] words = input.Split('-');
        words = words.Select(element => wordToCamelCase(element));
    
        return string.Join("", words);
    }
    
    string wordToCamelCase(string input)
    {
        return input.First().ToString().ToUpper() + input.Substring(1).ToLower();
    }
