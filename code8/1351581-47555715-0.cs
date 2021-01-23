    public static Tuple<int, int> FindTwoSum(IList<int> list, int sum)
    {
        HashSet<int> hs = new HashSet<int>();
        for (int i = 0; i < list.Count; i++)
        {
            var needed = sum - list[i];
            if (hs.Contains(needed))
            {
                return Tuple.Create(list.IndexOf(needed), i);
            }
            hs.Add(list[i]);                
        }
        return null;
    }
