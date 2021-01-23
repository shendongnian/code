    class DataIterator<T> : IEnumerable<T[]> {
        private readonly IList<IList<T>> _lists;
        public DataIterator(IList<IList<T>> lists) {
            Contract.Assert(lists.All(l => l.Count == lists[0].Count));
            _lists = lists; 
        }
        public IEnumerator<T[]> GetEnumerator() {
            var value = new List<T>(_lists.Count);
            for (var i = 0; i < _lists[0].Count; i++) {
                value.AddRange(_lists.Select(t => t[i]));
                yield return value.ToArray();
                value = new List<T>(_lists.Count);
            }
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
