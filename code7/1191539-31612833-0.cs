    public static IEnumerable<DateTime> DateRange(DateTime startInclusive, DateTime endInclusive)
    {
        for (var current = startInclusive; current <= endInclusive; current = current.AddDays(1))
        {
            yield return current;
        }
    }
