    public static IEnumerable<Byte> AddAdditional10If10(IEnumerable<Byte> values)
    {
        foreach (var b in values)
        {
            if (b == 10)
            { 
                yield return 10;
            }
            yield return b;
        }
    }
