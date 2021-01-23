    Dictionary<string, int> dict = new Dictionary<string, int>();
    for(int i = 0; brandList.Count; i++)
    {
        string brand = brandList[i];
        int count = 1;
        if(dict.ContainsKey(brand))
            count = dict[brand] + 1;
        dict[brand] = count;
    }
