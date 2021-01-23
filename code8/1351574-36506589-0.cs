    public static Tuple<int, int> FindTwoSum(IList<int> list, int sum)
    {
        var lookup = list.Select((x, i) => new { Index = i, Value = x })
                         .ToLookup(x => x.Value, x => x.Index);
        for (int i = 0; i < list.Count; i++)
        {
            int diff = sum - list[i];
            if (lookup.Contains(diff))
                return Tuple.Create(i, lookup[diff].First());
        }
        return null;
    }
