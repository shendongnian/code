    private static IEnumerable<int> TestRange
    {
        get
        {
            int i = 0;
            while(i < 10)
                yield return i++;
        }
    }
