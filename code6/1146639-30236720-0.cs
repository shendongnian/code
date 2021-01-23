    public int Compare(string x, string y)
    {
        var rx = new Regex("^(d+)");
        var xRes = rx .Match(x);
        var yRes = rx .Match(y);
        if (xRes.Success 
             && yRes.Success)
        {
            return int.Parse(xRes.Groups[1].Value).
                   CompareTo(int.Parse(yRes.Groups[1].Value));
        }
        return x.CompareTo(y);
    }
