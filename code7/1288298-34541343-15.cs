    public static IEnumerable<IEnumerable<T>> GetAllPossibleCombinations<T>(this IEnumerable<T> source)
    {
        var result = new List<IEnumerable<T>>().AsEnumerable();
        for (int i = 1; i <= source.Count(); i++)
        {
            var intermediateResult = Enumerable.Range(1, i)
                    .Select(x => source.AsEnumerable()).CartesianProduct();
            result = result.Union(intermediateResult);
        }
        return result;
    }
