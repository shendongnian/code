    public T this[int index]
    {
        get
        {
            if (index >= this._size)
                throw new ArgumentOutOfRangeException("...");
            return this._items[index];
        }
        set
        {
            if (index >= this._size)
                throw new ArgumentOutOfRangeException("...");
            this._items[index] = value;
        }
    }
