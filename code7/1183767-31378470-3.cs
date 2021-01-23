    SortedDictionary<double, SortedDictionary<double, List<Obj>>> sortedLookup =
        new SortedDictionary<double, SortedDictionary<double, List<Obj>>>();
    public void Add(Obj obj)
    {
        SortedDictionary<double, List<Obj>> value;
        bool exists = sortedLookup.TryGetValue(obj.V1, out value);
        if(!exists)
        {
            value = new SortedDictionary<double, List<Obj>>(){{obj.V2, new List<Obj>{obj}}};
            sortedLookup.Add(obj.V1, value);
        }
        else
        {
            List<Obj> list;
            exists = value.TryGetValue(obj.V2, out list);
            if (!exists)
                list = new List<Obj> { obj };
            value[obj.V2] = list;
            sortedLookup[obj.V1] = value;
        }
    }
    public Obj GetMaxItem()
    {
        if (sortedLookup.Count == 0) return null;
        Obj maxV1Item = sortedLookup.Last().Value.Last().Value.Last();
        return maxV1Item;
    }
