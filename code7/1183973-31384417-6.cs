    Dictionary<string, int> itemCounts = new Dictionary<string,int>();
    for(int i = 0; i < stringLists.Length; i++)
    {
        List<string> list = stringLists[i];
        foreach(string str in list.Distinct())
        {
            if(itemCounts.ContainsKey(str))
               itemCounts[str] += 1;
            else
                itemCounts.Add(str, 1);
        }
    }
    var result = itemCounts.Where(kv => kv.Value >= 2);
