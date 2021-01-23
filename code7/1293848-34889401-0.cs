        private static IEnumerable<IGrouping<TKey, TElement>> GroupAdjacentImpl<TSource, TKey, TElement>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            IEqualityComparer<TKey> comparer)
        {
            Debug.Assert(source != null);
            Debug.Assert(keySelector != null);
            Debug.Assert(elementSelector != null);
            Debug.Assert(comparer != null);
            using (var iterator = source.Select(item => new KeyValuePair<TKey, TElement>(keySelector(item), elementSelector(item)))
                                        .GetEnumerator())
            {
                var group = default(TKey);
                var members = (List<TElement>) null;
                while (iterator.MoveNext())
                {
                    var item = iterator.Current;
                    if (members != null && comparer.Equals(group, item.Key))
                    {
                        members.Add(item.Value);
                    }
                    else
                    {
                        if (members != null)
                            yield return CreateGroupAdjacentGrouping(group, members);
                        group = item.Key;
                        members = new List<TElement> { item.Value };
                    }
                }
                if (members != null)
                    yield return CreateGroupAdjacentGrouping(group, members);
            }
        }
        private static Grouping<TKey, TElement> CreateGroupAdjacentGrouping<TKey, TElement>(TKey key, IList<TElement> members)
        {
            Debug.Assert(members != null);
            return Grouping.Create(key, members.IsReadOnly ? members : new ReadOnlyCollection<TElement>(members));
        }
        static class Grouping
        {
            public static Grouping<TKey, TElement> Create<TKey, TElement>(TKey key, IEnumerable<TElement> members)
            {
                return new Grouping<TKey, TElement>(key, members);
            }
        }
        #if !NO_SERIALIZATION_ATTRIBUTES
        [Serializable]
        #endif
        private sealed class Grouping<TKey, TElement> : IGrouping<TKey, TElement>
        {
            private readonly IEnumerable<TElement> _members;
            public Grouping(TKey key, IEnumerable<TElement> members)
            {
                Debug.Assert(members != null);
                Key = key;
                _members = members;
            }
            public TKey Key { get; private set; }
            public IEnumerator<TElement> GetEnumerator()
            {
                return _members.GetEnumerator();
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
