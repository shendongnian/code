    public static Tuple<int, int> FindTwoSum(int[] collection, int sum)
    {
        int[] distinct = collection.Distinct().ToArray();
        for (int x = 0; x < distinct.Length; x++)
        {
            for (int y = 0; y < distinct.Length; y++)
            {
                if (y != x && distinct[x] + distinct[y] == sum)
                    return Tuple.Create(Array.IndexOf(collection, distinct[x]), Array.IndexOf(collection, distinct[y]));
            }
        }
        return null;
    }
