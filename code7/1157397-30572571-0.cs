    public static IEnumerable<long> Dates(long start, int step, Func<bool> condition)
    {
        var k = start + step;
    
        while (condition())
        {
            k += step;
            yield return k;
        }
    }
