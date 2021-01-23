    public Array ConvertAll<TInput, TOutput>(Array input, Func<TInput, TOutput> converter)
    {
        var rank = input.Rank;
        var lengths = Enumerable.Range(0, rank).Select(i => input.GetLength(i)).ToArray();
        var lowerBounds = Enumerable.Range(0, rank).Select(i => input.GetLowerBound(i)).ToArray();
        var upperBounds = Enumerable.Range(0, rank).Select(i => input.GetUpperBound(i));
        var output = Array.CreateInstance(typeof(TOutput), lengths, lowerBounds);
        ConvertRank(input, converter, output, new int[0], lowerBounds.Zip(upperBounds, Tuple.Create).ToArray());
        return output;
    }
    
    private void ConvertRank<TInput, TOutput>(Array input, Func<TInput, TOutput> converter, Array output, int[] indices, Tuple<int, int>[] bounds)
    {
        if (!bounds.Any())
        {
            var value = input.GetValue(indices);
            var convertedValue = converter((TInput)value);
            output.SetValue(convertedValue, indices);
        }
        else
        {
            var start = bounds[0].Item1;
            var end = bounds[0].Item2;
            var tail = bounds.Skip(1).ToArray();
            for (var i = start; i <= end; i++)
                ConvertRank(input, converter, output, indices.Concat(new[] { i }).ToArray(), tail);
        }
    }
