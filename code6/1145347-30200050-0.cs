    class MyOrderedEnumerable<TKey, TValue> : IOrderedEnumerable<TValue> {
         private SortedList<TKey, TValue> sortedList;
         public MyOrderedEnumerable(SortedList<TKey, TValue> sortedList) {
            this.sortedList = sortedList;
         }
         public IOrderedEnumerable<TValue> CreateOrderedEnumerable<TKey1>(Func<TValue, TKey1> keySelector, IComparer<TKey1> comparer, bool descending) {
            throw new NotImplementedException();
         }
         public IEnumerator<TValue> GetEnumerator() {
            return new Enumerator(sortedList.GetEnumerator());
         }
         IEnumerator IEnumerable.GetEnumerator() {
            return new Enumerator(sortedList.GetEnumerator());
         }
         class Enumerator : IEnumerator<TValue> {
            private IEnumerator<KeyValuePair<TKey, TValue>> inner;
            public Enumerator(IEnumerator<KeyValuePair<TKey, TValue>> inner) {
               this.inner = inner;
            }
            public TValue Current {
               get {
                  return inner.Current.Value;
               }
            }
            object IEnumerator.Current {
               get {
                  return inner.Current.Value;
               }
            }
            public void Dispose() {
               this.inner.Dispose();
            }
            public bool MoveNext() {
               return this.inner.MoveNext();
            }
            public void Reset() {
               this.inner.Reset();
            }
         }
      }
