    static T[] MaxElements<T>(params T[][] arrays) where T : IComparable<T>
    {
        return Enumerable.Range(0, arrays[0].Length)
                         .Select(i => Enumerable.Range(0, arrays.Length)
                                                .Select(a => arrays[a][i]).Max()).ToArray();
    }
