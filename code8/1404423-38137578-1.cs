    Dictionary<int, string> incrementalArray = new Dictionary<int, string>(); ;
    for (int i = 1; i < strings.Count(); i++)
    {
       incrementalArray.Add(i, String.Format("newProcessInfo{0}", i.ToString()));
    }
