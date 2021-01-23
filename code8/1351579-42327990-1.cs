    public static Tuple<int, int> FindTwoSum(IList<int> list, int sum)
    {
        for (int i = 0; i < list.Count; i++)
        {
          // subtract the item to the sum to find the difference
            int diff = sum - list[i];
          // if that number exist in that list find its index
            if (list.Contains(diff))
            {
                return Tuple.Create(i, list.IndexOf(diff));
            }
        }
        return null;
    } 
