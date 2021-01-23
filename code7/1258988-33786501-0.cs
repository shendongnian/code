    public static IList<Stock> GetSome(List<Stock> input)
    {
        var result = new List<Stock>();
        if (input.Count < 8)
        {
            result.Add(input.First());
            result.Add(input.Last());
        }
        else
        {
            for (int i = 0; i < input.Count; ++i)
            {
                if (i % 8 == 0)
                {
                    result.Add(input[i]);
                }
            }
            result.Add(input.Last());
        }
        return result;
    }
