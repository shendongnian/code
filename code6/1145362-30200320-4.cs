    public class SortedListOrderedEnumerable<TKey, TValue> : IOrderedEnumerable<TValue>
    {
        private readonly SortedList<TKey, TValue> innerList;
        public SortedListOrderedEnumerable(SortedList<TKey, TValue> innerList)
        {
            this.innerList = innerList;
        }
        public IOrderedEnumerable<TValue> CreateOrderedEnumerable<TKey1>(Func<TValue, TKey1> keySelector, IComparer<TKey1> comparer, bool @descending)
        {
            return @descending 
                ? innerList.Values.OrderByDescending(keySelector, comparer) 
                : innerList.Values.OrderBy(keySelector, comparer);
        }
        public IEnumerator<TValue> GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public static class Ext
    {
        public static IOrderedEnumerable<TValue> AsOrderedEnumerable<TKey, TValue>(
            this SortedList<TKey, TValue> list)
        {
            return new SortedListOrderedEnumerable<TKey, TValue>(list);
        } 
    }
