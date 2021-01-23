    public List<T> GetRange(int index, int count)
    {
        if (index < 0)
        {
            ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
        }
        if (count < 0)
        {
            ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
        }
        if ((this._size - index) < count)
        {
            ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidOffLen);
        }
        List<T> list = new List<T>(count);
        Array.Copy(this._items, index, list._items, 0, count); // Implemented natively
        list._size = count;
        return list;
    }
