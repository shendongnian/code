    static string InsertBeforeUpperCases(this string source, string value)
    {
        var result = new StringBuilder();
        bool previousWasLower = false;
        for (int i = 0; i < source.Length; i++)
        {
            char c = source[i];
            bool isLower = char.IsLower(c);
            if (previousWasLower && !isLower)                
                result.Append(value);                
            result.Append(c);
            previousWasLower = isLower;
        }
        return result.ToString();
    }
