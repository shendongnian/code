    [__DynamicallyInvokable]
    public int IndexOf(T item, int index)
    {
        if (index > this._size)
        {
            ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_Index);
        }
        return Array.IndexOf<T>(this._items, item, index, this._size - index);
    }
