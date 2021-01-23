    public static string SomeMethod(Dictionary<string, string> dictionary, string str)
    {
        foreach (var kv in dictionary)
        {
            var rx = new Regex(kv.Key);
            if (rx.IsMatch(str))
            {
                string replaced = rx.Replace(str, kv.Value);
                return replaced;
            }
        }
        return str;
    }
    Dictionary<string, string> dictionary = new Dictionary<string, string>()
    {
        { "SPROC:(.*)", "$1" }
    };
    string replaced = SomeMethod(dictionary, "SPROC:my_sproc");
