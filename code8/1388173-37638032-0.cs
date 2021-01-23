    List<string>[][] lists = new List<string>[26][6];
    foreach (string s in keys)
    {
        var list = lists[s[0] - 'A'][s.Length - 5];
        if (list == null)
        {
            lists[s[0] - 'A'][s.Length] = list = new List<string>();
        }
        int ix = list.BinarySearch(s);
        if (ix < 0)
        {
            list.Insert(~ix, s);
        }
    }
