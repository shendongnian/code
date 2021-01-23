    string FixEncoding(string badString, Encoding bad, Encoding good)
    {
        var bytes = bad.GetBytes(badString);
        return good.GetString(bytes);
    }
    
    ...
    
    string fixedString = FixEncoding("GraÅ£iela", Encoding.Default, Encoding.UTF8); // Graţiela
