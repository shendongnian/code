    public List<int[]> FindDistinctWithoutLinq(List<int[]> lst)
    {
        var dic = new Dictionary<string, int[]>();
        foreach (var item in lst)
        {
            string key = string.Join(",", item.OrderBy(c=>c));
            if (!dic.ContainsKey(key))
            {
                dic.Add(key, item);
            }
        }
        return dic.Values.ToList();
    }
