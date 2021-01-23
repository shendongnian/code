    SortedDictionary<double, SortedSet<Obj>> sortedLookup = 
        new SortedDictionary<double, SortedSet<Obj>>(); // key is V1 and value all items with that value
    internal class ObjV2Comparer : IComparer<Obj>
    {
        public int Compare(Obj x, Obj y)
        {
            return x.V2.CompareTo(y.V2);
        }
    }
    private static readonly ObjV2Comparer V2Comparer = new ObjV2Comparer();
    public void Add(Obj obj)
    {
        SortedSet<Obj> set;
        bool exists = sortedLookup.TryGetValue(obj.V1, out set);
        if(!exists) 
            set = new SortedSet<Obj>(V2Comparer);
        set.Add(obj);
    }
    public Obj GetMaxItem()
    {
        if (sortedLookup.Count == 0) return null;
        Obj maxV1Item = sortedLookup.Last().Value.Last();
        return maxV1Item;
    }
