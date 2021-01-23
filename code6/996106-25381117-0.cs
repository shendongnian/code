    public string MyPrefixReplace(string source, string value, string delimiter = ".")
    {
        var parts = source.Split(delimiter);
        parts[0] = value;
        return String.Join(delimiter, parts);   
    }
