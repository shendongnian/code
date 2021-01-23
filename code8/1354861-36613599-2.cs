    public static IEnumerable<IEnumerable<T>> SplitIntoSetsOfSpecifiedLength<T>
        (this IEnumerable<T> source, int itemsPerSet) // naming is hard
    {
        var sourceArray = source as T[] ?? source.ToArray();
        var result = new List<IEnumerable<T>>();
        for (var index = 0; index < sourceArray.Length; index += itemsPerSet)
        {
            result.Add(sourceArray.Skip(index).Take(itemsPerSet));
        }
        return result;
    }
