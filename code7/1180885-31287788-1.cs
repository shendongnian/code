    public static class GroupExtensions
    {
        public IGrouping<TKey, TElement, TOrderKey> OrderBy
            (this IGrouping<TKey, TElement> grouping,
             Func<TElement, TOrderKey> orderKeySelector)
        {
            return new GroupingImpl<TKey, TElement>
                (grouping.Key, grouping.OrderBy(orderKeySelector));
        }
    
        private class GroupingImpl<TKey, TElement> : IGrouping<TKey, TElement>
        {
            private readonly TKey key;
            private readonly List<TElement> elements;
            internal GroupingImpl(TKey key, IEnumerable<TElement> elements)
            {
                this.key = key;
                this.elements = elements.ToList();
            }
            public TKey Key { get { return key; } }
            public IEnumerator<TElement> GetEnumerator()
            {
                return elements.GetEnumerator();
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
