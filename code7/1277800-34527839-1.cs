    public static char[][] split_string(string str)
    {
        var list = new List<char[]>();
        foreach (string s in str.Split(' '))
        {
            list.Add(s.ToCharArray());
        }
        return list.ToArray();
    }
