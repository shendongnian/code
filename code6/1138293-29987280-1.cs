    public static int? GetLargestNonNull(params int?[] values)
    {
        IEnumerable<int?> nonNullValues = values.Where(v => v.HasValue);
        
        if (nonNullValues.Any())
        {
            return nonNullValues.Select(v => v.Value).Max();
        }
        
        return null;
    }
