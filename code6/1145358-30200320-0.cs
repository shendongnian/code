    public class SortedListOrderedEnumerable<TKey, TValue> : IOrderedEnumerable<KeyValuePair<TKey, TValue>>
    {
        private readonly SortedList<TKey, TValue> innerList;
        public SortedListOrderedEnumerable(SortedList<TKey, TValue> innerList)
        {
            this.innerList = innerList;
        }
        public IOrderedEnumerable<KeyValuePair<TKey, TValue>> CreateOrderedEnumerable<TKey1>(Func<KeyValuePair<TKey, TValue>, TKey1> keySelector, IComparer<TKey1> comparer, bool @descending)
        {
            return @descending ? innerList.OrderByDescending(keySelector, comparer) : innerList.OrderBy(keySelector, comparer);
        }
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public static class Ext
    {
        public static IOrderedEnumerable<KeyValuePair<TKey, TValue>> AsOrderedEnumerable<TKey, TValue>(
            this SortedList<TKey, TValue> list)
        {
            return new SortedListOrderedEnumerable<TKey, TValue>(list);
        } 
    }
