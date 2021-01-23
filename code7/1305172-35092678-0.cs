    public class BList<T> : IList<T>, IReadOnlyList<T>
    {
        private const int InitialCapacity = 16;
        private const int InitialOffset = 8;
        private int _size;
        private int _offset;
        private int _capacity;
        private T[] _items;
        public BList()
        {
            _size = 0;
            _offset = InitialOffset;
            _capacity = InitialCapacity;
            _items = new T[InitialCapacity];
        }
        private void Insert(int insertIndex, T[] insertItems)
        {
            if (insertIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(insertIndex));
            var insertCount = insertItems.Length;
            var padRight = Math.Max(0, (insertIndex == 0)
                ? (insertCount - (_size + 1))
                : (insertIndex + insertCount) - (_size));
            var padLeft = insertIndex == 0
                ? insertCount
                : 0;
            var requiresResize = _offset - padLeft < 0 ||
                                 _offset + _size + padRight > _capacity;
            if (requiresResize)
            {
                var newSize = _size + insertCount;
                var newCapacity = Math.Max(newSize, _capacity*2);
                var newOffset = (newCapacity/2) - (newSize/2) - padLeft;
                var newItems = new T[newCapacity];
                for (int i = 0; i < insertIndex; i++)
                    newItems[newOffset + i] = _items[_offset + i];
                for (int i = insertIndex; i < _size; i++)
                    newItems[newOffset + i + insertCount] = _items[_offset + i];
                for (int i = 0; i < insertCount; i++)
                    newItems[newOffset + insertIndex + i] = insertItems[i];
                _items = newItems;
                _offset = newOffset;
                _size = newSize;
                _capacity = newCapacity;
            }
            else
            {
                if (insertIndex == 0)
                    _offset = _offset - insertCount;
                else
                    for (int i = _size - 1; i >= insertIndex; i--)
                        _items[_offset + i + insertCount] = _items[_offset + i];
                for (int i = 0; i < insertCount; i++)
                    _items[_offset + insertIndex + i] = insertItems[i];
                _size = _size + insertCount;
            }
        }
        
        public void Insert(int insertIndex, T item)
        {
            Insert(insertIndex, new[] { item });
        }
