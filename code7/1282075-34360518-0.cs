    public static IEnumerable<int> GetValues(int i, int minValue, int maxValue, int valueCount)
    {
        i = i - 1; //adjust to zero indexing format
        var range = maxValue - minValue + 1;
        for (int j = 0; j < valueCount; j++)
        {
            yield return i % range + minValue;
            i = i / range;
        }
    }
