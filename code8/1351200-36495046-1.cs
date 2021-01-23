    public static List<TResult> Filter<TResult>(List<TResult> input, Predicate<TResult> closure)
    {
        if (input == null || input.Count == 0)
            return new List<TResult>();
        else
            return (closure(input.First()) ? new List<TResult> {input.First()} : new List<TResult>())
                // Replace '+'
                .Union(Filter(input.Skip(1).ToList(), closure)).ToList();
    }
