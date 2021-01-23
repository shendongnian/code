    public static char[][] split_string(char[] str)
    {
        var list = new List<char[]>();
        foreach (string s in (new string(str)).Split(' '))
        {
            list.Add(s.ToCharArray());
        }
        return list.ToArray();
    }
