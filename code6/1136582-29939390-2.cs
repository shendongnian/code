    public static IEnumerable<IGrouping<TKey, TElement>> GroupAdjacent<TKey, TElement>(
        this IEnumerable<TElement> source, Func<TElement, TKey> keySelector)
    {
        var comparer = Comparer<TKey>.Default;
        using (var iterator = source.GetEnumerator())
        {
            if(!iterator.MoveNext())
            {
                yield break;
            }
            else
            {
                var group = new Grouping<TKey, TElement>(keySelector(iterator.Current));
                group.Add(iterator.Current);
                while(iterator.MoveNext())
                {
                    TKey key = keySelector(iterator.Current);
                    if (comparer.Compare(key, group.Key) != 0)
                    {
                        yield return group;
                        group = new Grouping<TKey, TElement>(key);
                    }
                            
                    group.Add(iterator.Current);                        
                }
                if (group.Any())
                    yield return group;
            }
        }
    }
