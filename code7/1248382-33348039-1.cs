    private static int[] SortIntArrayWithDuplicates(IEnumerable<int> intArray)
    {
        var enumerable = intArray as int[] ?? intArray.ToArray();
        return enumerable.Where(x => x < 0)
            .Concat(enumerable.Where(x => x >= 0))
            .ToArray();
    }
    private static int[] SortIntArrayWithoutDuplicates(IEnumerable<int> intArray)
    {
        var enumerable = intArray as int[] ?? intArray.ToArray();
        return enumerable.Where(x => x < 0)
            .Union(enumerable.Where(x => x >= 0))
            .ToArray();
    }
