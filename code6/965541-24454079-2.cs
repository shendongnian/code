    public static IEnumerable<object> GetEvents(DateTime startTime)
    {
        for (int i = 0; i < 3000; i++)
        {
            if (i % 2 == 0) //is even
            {
                yield return new
                {
                    TimeId = startTime.AddSeconds(i),
                    ValueStart = i
                };
            }
        }
    }
