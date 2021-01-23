    internal class 
        ChunkWhenNextSequenceElementIsNotGreaterEnumerable<T> : 
            IEnumerable<T>
    {
        #region Constructor.
        internal ChunkWhenNextSequenceElementIsNotGreaterEnumerable(
            IEnumerator<T> enumerator, Comparison<T> comparer)
        {
            // Validate parameters.
            if (enumerator == null) 
                throw new ArgumentNullException("enumerator");
            if (comparer == null) 
                throw new ArgumentNullException("comparer");
            // Assign values.
            _enumerator = enumerator;
            _comparer = comparer;
        }
        #endregion
        #region Instance state.
        private readonly IEnumerator<T> _enumerator;
        private readonly Comparison<T> _comparer;
        internal bool LastMoveNext { get; private set; }
        #endregion
        #region IEnumerable implementation.
        public IEnumerator<T> GetEnumerator()
        {
            // The assumption is that a call to MoveNext 
            // that returned true has already
            // occured.  Store as the previous value.
            T previous = _enumerator.Current;
            // Yield it.
            yield return previous;
            // While can move to the next item, and the previous 
            // item is less than or equal to the current item.
            while ((LastMoveNext = _enumerator.MoveNext()) && 
                _comparer(previous, _enumerator.Current) < 0)
            {
                // Yield.
                yield return _enumerator.Current;
                // Store the previous.
                previous = _enumerator.Current;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
