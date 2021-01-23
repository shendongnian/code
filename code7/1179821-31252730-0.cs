    public static string Replacements(string text)
    {
        string output = text;
        foreach (KeyValuePair<string, string> item in dict1)
        {
            //here replace output again
            output = Regex.Replace(output, item.Key, item.Value); 
              
        }
        return output;
    }
