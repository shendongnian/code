    var dic = new Dictionary<string, string>();
    dic.Add("hello", "bob");
    dic.Foreach(x =>
    {
       Console.WriteLine(x.Key + x.Value);
    });
    public static void Foreach<T, TY>(this Dictionary<T, TY> collection,   Action<T, TY> action)
    {
        foreach (var kvp in collection)
        {
            action.Invoke(kvp.Key, kvp.Value);
        }
    }
