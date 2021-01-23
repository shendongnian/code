    public class UnwoundItem<T> : IEnumerable<UnwoundItem<T>>
    {
        private readonly T _item;
        private readonly IEnumerable<UnwoundItem<T>> _unwoundItems;
        public UnwoundItem(T item, IEnumerable<UnwoundItem<T>> unwoundSubItems)
        {
            this._item = item;
            this._unwoundItems = unwoundSubItems ?? Enumerable.Empty<UnwoundItem<T>>();
        }
        public T Item
        {
            get
            {
                return this._item;
            }
        }
        public IEnumerable<UnwoundItem<T>> UnwoundSubItems
        {
            get
            {
                return this._unwoundItems;
            }
        }
        public IEnumerator<UnwoundItem<T>> GetEnumerator()
        {
            return this._unwoundItems.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
