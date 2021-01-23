    public static int? GetLargestNonNull(params int?[] values)
    {
        int? result = null;
        
        foreach (var valueToCheck in values)
        {
            if (valueToCheck.HasValue)
            {
                if (!result.HasValue)
                {
                    result = valueToCheck;
                }
                else if (valueToCheck.Value > result.Value)
                {
                    result = valueToCheck;
                }
            }
        }
        
        return result;
    }
