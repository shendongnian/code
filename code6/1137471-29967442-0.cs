    public static IDictionary<int, SortedList<int, List<int>>> Intersect(IDictionary<int, SortedList<int, List<int>>> x, IDictionary<int, SortedList<int, List<int>>> y) {
        IDictionary<int, SortedList<int, List<int>>> one = x.Keys.Intersect(y.Keys).ToDictionary(k => k, k => x[k]);
        foreach (KeyValuePair<int, SortedList<int, List<int>>> kvp in one.ToList()) {
            one[kvp.Key] = new SortedList<int,List<int>>(kvp.Value.Keys.Intersect(y[kvp.Key].Keys).ToDictionary(k => k, k => y[kvp.Key][k]));
        }
        return one;
    }
