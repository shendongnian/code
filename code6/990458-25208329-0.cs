    public static bool ContainsAll(this string str, params string[] values)
    {
        foreach( var value in values )
        {
            if (!str.Contains(value)) return false;
        }
        return true;
    }
