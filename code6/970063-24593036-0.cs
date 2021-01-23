    public void Add(T item) {
        if (_size == _items.Length) EnsureCapacity(_size + 1);
        _items[_size++] = item;
        _version++;
    }
    private void EnsureCapacity(int min) {
        if (_items.Length < min) {
            int newCapacity = _items.Length == 0? _defaultCapacity : _items.Length * 2;
            if (newCapacity < min) newCapacity = min;
            Capacity = newCapacity;
        }
    }
    public int Capacity {
        get { return _items.Length; }
        set {
            if (value != _items.Length) {
                if (value < _size) {
                    ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.value, ExceptionResource.ArgumentOutOfRange_SmallCapacity);
                }
  
                if (value > 0) {
                    T[] newItems = new T[value];
                    if (_size > 0) {
                        Array.Copy(_items, 0, newItems, 0, _size);
                    }
                    _items = newItems;
                }
                else {
                    _items = _emptyArray;
                }
            }
        }
    }
