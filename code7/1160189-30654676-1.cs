    private static void SortByKeys<T>(int[] keys, T[] values)
    {
        int[] keysCopy = (int[])keys.Clone();
        Array.Sort(keysCopy, values);
    }
