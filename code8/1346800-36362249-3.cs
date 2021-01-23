    private static string Replace(string input, IDictionary<string, string> replacements)
    {
        string result = regex.Replace(input, m => {
            
            string name = m.Groups["name"].Value;
            string value;
            if (replacements.TryGetValue(name, out value))
            {
                return value;
            }
            else   
            {
                return m.Captures[0].Value;
            }
        });
        
        return result;
    }
