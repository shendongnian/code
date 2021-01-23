    public class BList<T> : IList<T>, IReadOnlyList<T>
    {
        private const int InitialCapacity = 16;
        private const int InitialOffset = 8;
        private int _size;
        private int _offset;
        private int _capacity;
        private int _version;
        private T[] _items;
        public BList()
        {
            _version = 0;
            _size = 0;
            _offset = InitialOffset;
            _capacity = InitialCapacity;
            _items = new T[InitialCapacity];
        }
        public BList(int initialCapacity)
        {
            _size = 0;
            _version = 0;
            _offset = initialCapacity/2;
            _capacity = initialCapacity;
            _items = new T[initialCapacity];
        }
        public void Insert(int insertIndex, T item)
        {
            if (insertIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(insertIndex));
            var padRight = Math.Max(0, (insertIndex == 0) ? 0 : (insertIndex + 1) - _size);
            var padLeft = insertIndex == 0 ? 1 : 0;
            var requiresResize = _offset - padLeft <= 0 ||
                                    _offset + _size + padRight >= _capacity;
            if (requiresResize)
            {
                var newSize = _size + 1;
                var newCapacity = Math.Max(newSize, _capacity * 2);
                var newOffset = (newCapacity / 2) - (newSize / 2) - padLeft;
                var newItems = new T[newCapacity];
                Array.Copy(_items, _offset, newItems, newOffset, insertIndex);
                Array.Copy(_items, _offset, newItems, newOffset + 1, _size - insertIndex);
                newItems[newOffset + insertIndex] = item;
                _items = newItems;
                _offset = newOffset;
                _size = newSize;
                _capacity = newCapacity;
            }
            else
            {
                if (insertIndex == 0)
                    _offset = _offset - 1;
                else if (insertIndex < _size)
                    Array.Copy(_items, _offset + insertIndex, _items, _offset + insertIndex + 1, _size - insertIndex);
                _items[_offset + insertIndex] = item;
                _size = _size + 1;
            }
            _version++;
        }
