    public static IEnumerable<TResult> RecursiveFilter<TResult>(IEnumerable<TResult> input, Predicate<TResult> closure)
    {
        // Break on end
        if (input == null || !input.Any())
            yield break;
        // Keep going
        if (closure(input.First()))
            yield return current;
        // Recursive progression
        foreach (var filtered in RecursiveFilter(input.Skip(1), closure))
        {
            yield return filtered;
        }
    }
