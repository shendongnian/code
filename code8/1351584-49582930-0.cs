    public static Tuple<int, int> FindTwoSum(IList<int> list, int target)
    {
        var dict = new Dictionary<int, int>();
        for (int i = 0; i < list.Count; i++)
        {
            var diff = target - list[i];
            int j = -1;
            if(dict.TryGetValue(diff, out j))
            {
                return Tuple.Create<int, int>(j, i);
            }
            dict[list[i]] = i;
        }
        return null;
    }
