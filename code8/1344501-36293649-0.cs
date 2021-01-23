    public static Tuple<int, int> FindTwoSumFaster(IList<int> list, int sum)
    {
        if (list == null)
            throw new NullReferenceException("Null list");
        // constructing a hashset to have O(1) operations
        var listSet = new HashSet<int>();
        // number -> index mapping
        // O(n) complexity
        var listReverseSet = new Dictionary<int, int>();
        int i = 0;
        foreach (var elem in list)
        {
            if (!listSet.Contains(elem))
                listSet.Add(elem);
            listReverseSet[elem] = i++;
        }
        // O(n) complexity
        int listCount = list.Count;
        for (int index = 0; index < listCount; index ++)
        {
            var elem = list[index];
            if (listSet.Contains(sum - elem))
                return new Tuple<int, int>(index, listReverseSet[sum - elem]);
        }
        return null;
    }
