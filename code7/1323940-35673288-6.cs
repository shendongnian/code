    public Array ConvertAll<TInput, TOutput>(Array input, Func<TInput, TOutput> converter)
    {
        var rank = input.Rank;
        var lengths = Enumerable.Range(0, rank).Select(i => input.GetLength(i)).ToArray();
        var output = Array.CreateInstance(typeof(TOutput), lengths);
        ConvertRank(input, converter, output, new int[0], lengths);
        return output;
    }
    private void ConvertRank<TInput, TOutput>(Array input, Func<TInput, TOutput> converter, Array output, int[] indices, int[] lengths)
    {
        if (!lengths.Any())
        {
            var value = input.GetValue(indices);
            var convertedValue = converter((TInput)value);
            output.SetValue(convertedValue, indices);
        }
        else
        {
            var tail = lengths.Skip(1).ToArray();
            for (int i = 0, length = lengths[0]; i < length; i++)
                ConvertRank(input, converter, output, indices.Concat(new[] { i }).ToArray(), tail);
        }
    }
