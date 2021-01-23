    public class IndexedCollection<TIndex, TValue> : IList<TValue>
    {
        private List<TValue> _innerList;
        private Func<TIndex, int> _getIndex;
        
        public IndexedCollection(Func<TIndex, int> getIndex)
        {
            this._getIndex = getIndex;
            this._innerList = new List<TValue>();
        }
        new public TValue this[TIndex indexObj]
        {
            get 
            {
                var realIndex = this._getIndex(indexObj);
                return _innerList[realIndex];
            }
            set 
            {
                _innerList[this._getIndex(indexObj)] = value;
            }
        }
        // All the other members
    }
