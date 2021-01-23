    public int IndexOf(T item, int index) {
        if (index > _size)
            ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_Index);
        Contract.Ensures(Contract.Result<int>() >= -1);
        Contract.Ensures(Contract.Result<int>() < Count);
        Contract.EndContractBlock();
        return Array.IndexOf(_items, item, index, _size - index);
    }
