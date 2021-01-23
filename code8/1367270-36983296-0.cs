    Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
    foreach (var item in Directory.GetDirectories(@"C:\Users\user\Desktop\search Directory", "*.*", SearchOption.AllDirectories))
    {
        dict.Add(item, getMyfiles(item));
    }
