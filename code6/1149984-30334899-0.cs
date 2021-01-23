    public static IEnumerable<T> ChooseFromAll<T>(
        IEnumerable<IList<T>> lists,
        Random generator)
    {
        foreach (var list in lists)
            yield return list[generator.Next(list.Count)];
    }
