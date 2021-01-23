    public static T AnyOne<T>(this IEnumerable<T> source)
    {
        int endExclusive = source.Count(); // #1
        int randomIndex = Random.Range(0, endExclusive); 
        return source.ElementAt(randomIndex); // #2
    }
