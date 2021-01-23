    public class LfuCache<TKey, TValue>
    {
        private readonly Dictionary<TKey, LfuItem> _items;
        private readonly int _limit;
        private LfuItem _first, _last;
        public LfuCache(int limit, IEqualityComparer<TKey> keyComparer = null)
        {
            this._limit = limit;
            this._items = new Dictionary<TKey,LfuItem>(keyComparer);
        }
        public void Add(TKey key, TValue value)
        {
            if (this._items.Count == this._limit)
            {
                this.RemoveLast();
            }
            var lfuItem = new LfuItem { Key = key, Value = value, Prev = this._last };
            this._items.Add(key, lfuItem);
            if (this._last != null)
            {
                this._last.Next = lfuItem;
                lfuItem.Prev = this._last;
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
        private void RemoveLast()
        {
            if (this._items.Remove(this._last.Key))
            {
                this._last = this._last.Prev;
                if (this._last != null)
                {
                    this._last.Next = null;
                }
            }
        }
        private class LfuItem
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }
            public long UseCount { get; set; }
            public LfuItem Prev { get; set; }
            public LfuItem Next { get; set; }
        }
    }
