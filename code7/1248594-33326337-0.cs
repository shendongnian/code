    public string MyTryParse(string[] args, int index, string defaultVal)
    {
        return index < args.Length ? (args[index] ?? defaultVal) : defaultVal
    }
    ...
    string first = MyTryParse(args, 0, "c:\");
