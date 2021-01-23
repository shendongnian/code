    public class LfuCache<TKey, TValue>
    {
        private readonly Dictionary<TKey, LfuItem> _items;
        private LfuItem _first, _last;
        public LfuCache(IEqualityComparer<TKey> keyComparer = null)
        {
            this._items = new Dictionary<TKey,LfuItem>(keyComparer);
        }
        public void Add(TKey key, TValue value)
        {
            var lfuItem = new LfuItem { Value = value, Prev = this._last };
            this._items.Add(key, lfuItem);
            if (this._last != null)
            {
                this._last.Next = lfuItem;
            }
            
            this._last = lfuItem;
            
            if (this._first == null)
            {
                this._first = lfuItem;
            }
        }
        public TValue this[TKey key]
        {
            get
            {
                var lfuItem = this._items[key];
                ++lfuItem.UseCount;
                this.TryMoveUp(lfuItem);
                
                return lfuItem.Value;
            }
        }
        private void TryMoveUp(LfuItem lfuItem)
        {
            if (lfuItem.Prev == null || lfuItem.Prev.UseCount >= lfuItem.UseCount) // maybe > if you want LRU and LFU
            {
                return;
            }
            var prev = lfuItem.Prev;
            prev.Next = lfuItem.Next;
            lfuItem.Prev = prev.Prev;
            prev.Prev = lfuItem;
            if (lfuItem.Prev == null)
            {
                this._first = lfuItem;
            }
        }
        private class LfuItem
        {
            public TValue Value { get; set; }
            public long UseCount { get; set; }
            public LfuItem Prev { get; set; }
            public LfuItem Next { get; set; }
        }
    }
