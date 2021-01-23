    public static List<TOutput> MergeAll<TInput, TOutput>(this List<TInput> inputs,
                                            Func<TInput, TOutput> merger)
    {
        var outputs = new List<TOutput>();
        foreach (var input in inputs)
        {
            outputs.Add(merger(input));
        }
        return outputs;
    }
