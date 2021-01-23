    public static IEnumerable<IEnumerable<string>> Split(IEnumerable<string> tokens)
    {
        using(var iterator = tokens.GetEnumerator())
            while(iterator.MoveNext())
                if(iterator.Current == "[")
                    yield return SplitGroup(iterator);
    }
    
    public static IEnumerable<IEnumerable<string>> SplitGroup(
        IEnumerator<string> iterator)
    {
        while(iterator.MoveNext() && iterator.Current != "]")
            yield return iterator.Current;
    }
