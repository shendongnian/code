    int totalSelected = 0;
    foreach (string key in collection.AllKeys)
    {
        int subTotalSelected = collection.GetValues(key).Where(x => x.Contains("true")).Count();
        totalSelected += subTotalSelected;
    }
