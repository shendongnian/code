    public class SynchronizedCollectionWithMaxOnTop
    {
        double Max => _items[0].AbsoluteError;
        public ItemChangeState TryAdd(Item item, out Item removed)
        {
            ItemChangeState state;
            removed = null;
            if (_items.Count >= Limit && signal.AbsoluteError > Max)
                return ItemChangeState.NoAddedNoRemoved;
            lock (this)
            {
                if (_items.Count >= Limit)
                {
                    removed = Remove();
                    state = ItemChangeState.AddedAndRemoved;
                }
                else
                    state = ItemChangeState.AddedNoRemoved;
                Insert(item);
            }
            return state;
        }
        private void Insert(Item item)
        {
            _items.Add(item);
            HeapifyUp(_items.Count - 1);
        }
        private void Remove()
        {
            var result = new Item(_items[0]);
            var lastIndex = _items.Count - 1;
            _items[0] = _items[lastIndex];
            _items.RemoveAt(lastIndex);
            HeapifyDown(0);
            return result;
        }
    }
