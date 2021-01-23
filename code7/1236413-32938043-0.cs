    private static Array CreateArray(Array array)
    {
        List<int> dimensions = new List<int>();
        for (int i = 0; i < array.Rank; i++)
        {
            dimensions.Add(array.GetLength(i));
        }
        return Array.CreateInstance(typeof(bool), dimensions.ToArray());
    }
