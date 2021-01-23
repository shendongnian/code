    public static bool Contains(string source, string toCheck)
    {
        var results = Array.FindAll(source.split(','), s => s.Equals(toCheck));
        if(results.Length > 0)
            return true;
        else
            return false;
    }
