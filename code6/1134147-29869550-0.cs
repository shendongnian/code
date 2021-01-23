     public static class LINQExtensions
    {
        public static IEnumerable<IGrouping<TKey, TElement>> GroupAdjacentBy<TElement, TKey>(this IEnumerable<TElement> source, Func<TElement, TKey> keySelector, IEqualityComparer<TKey> comparer = null)
        {
            comparer = comparer ?? EqualityComparer<TKey>.Default;
            List<TElement> elements = null;
            TKey key = default(TKey);
            TKey lastKey = default(TKey);
            foreach (var x in source)
            {
                key = keySelector(x);
                if (elements != null && elements.Any() && !comparer.Equals(lastKey, key))
                {
                    yield return new Grouping<TKey, TElement>(lastKey, elements);
                    elements = null;
                }
                if (elements == null)
                {
                    elements = new List<TElement>();
                    lastKey = key;
                }
                elements.Add(x);
            }
            if (elements != null && elements.Any())
            {
                yield return new Grouping<TKey, TElement>(key, elements);
            }
        }
        public static IEnumerable<IGrouping<TElement, TElement>> GroupAdjacentBy<TElement>(this IEnumerable<TElement> source, IEqualityComparer<TElement> comparer = null)
        {
            return source.GroupAdjacentBy(keySelector: x => x, comparer: comparer);
        }
        // implement IGrouping
        public class Grouping<TKey, TElement> : IGrouping<TKey, TElement>
        {
            public TKey Key { get; private set; }
            private List<TElement> Elements { get; set; }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return ((IEnumerable<TElement>)this).GetEnumerator();
            }
            IEnumerator<TElement> IEnumerable<TElement>.GetEnumerator()
            {
                return ((IEnumerable<TElement>)Elements).GetEnumerator();
            }
            public Grouping(TKey key, List<TElement> elements)
            {
                Key = key;
                Elements = elements;
            }
        }
    }
