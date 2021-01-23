    public static IEnumerable<TOutput> UniquifyNames<TSource, TOutput>(
        this IEnumerable<TSource> source,
        Func<TSource, string> nameSelector,
        Func<TSource, string, TOutput> resultProjection
        )
    {
        HashSet<string> existingNames = new HashSet<string>();
        foreach (TSource item in source)
        {
            string name = nameSelector(item);
            yield return resultProjection(item, GenerateName(name, existingNames));
        }
    }
    private static string GenerateName(string name, HashSet<string> existingNames)
    {
        return Enumerable.Range(1, int.MaxValue)
            .Select(i =>
            {
                string suffix = i == 1
                    ? ""
                    : (name.EndsWithDigit() ? "-" : "") + i.ToString();
                return $@"{name}{suffix}";
            }).First(existingNames.Add);
    }
