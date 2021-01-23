    public static string Grid<T>(IEnumerable<T> collection)
    {
        ...........
        ...........
        foreach (T item in collection)
        {
            foreach (var p in classProperties )
            {
                string s = p.Name + ": " + p.GetValue(item, null);
            }
        }
    }
