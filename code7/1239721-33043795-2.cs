    private static Random r = new Random();
    public static int[] GetRandomArray(int size)
    {
        SortedDictionary<double, int> sortedSet = new SortedDictionary<double, int>();
        for (int index = 0; index < size; index++)
        {               
            sortedSet.Add(r.NextDouble(), index);
        }
        return sortedSet.Select(x => x.Value).ToArray();
    }
