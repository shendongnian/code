    public TOutput[,] ConvertAllx<TInput, TOutput>(TInput[,] input, Func<TInput, TOutput> converter)
    {
        var lengths = new[] { input.GetLength(0), input.GetLength(1) };
        var lowers = new[] { input.GetLowerBound(0), input.GetLowerBound(1) };
        var uppers = new[] { input.GetUpperBound(0), input.GetUpperBound(1) };
        var result = Array.CreateInstance(typeof(TOutput), lengths, lowers) as TOutput[,];
        for (int i = lowers[0], il = uppers[0]; i <= il; ++i)
        for (int j = lowers[1], jl = uppers[1]; j <= jl; ++j)
                result[i, j] = converter(input[i, j]);
        return result;
    }
