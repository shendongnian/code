    public static string[] split_string(string str)
    {
        var list = new List<string>();
        foreach (string s in str.Split(' '))
        {
            list.Add(s);
        }
        return list.ToArray();
    }
