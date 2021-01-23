    public static string intersection2(string x1, string x2)
    {
    
        string[] string1 = x1.Split(' ');
        string[] string2 = x2.Split(' ');
        string[] m = string1.Distinct().ToArray();
        string[] n = string2.Distinct().ToArray();
        string Test;
        var results = m.Intersect(n, StringComparer.OrdinalIgnoreCase);
        Test = String.Join(" ", results);
        return Test;
    }
 
