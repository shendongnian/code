    private static void load<T>(Dictionary<int, T> dict, string s)
    {
        dict.Clear();
        string[] items = s.Split(';');
        foreach (string item in items)
        {
            if (item.Contains("="))
            {
                string[] kv = item.Split('=');
                dict[int.Parse(kv[0])] = (T)Convert.ChangeType(kv[1], typeof(T));
            }
        }
    }
