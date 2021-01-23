    public string JustAscii(string source)
    {
        var retval = string.Empty;
        foreach (var c in source)
        {
            if (c > 127)
                continue;
            retval += c;
        }
    
        return retval;
    }
