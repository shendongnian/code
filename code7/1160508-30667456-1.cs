    public virtual T this[int index]
    {
        get
        {
            return (T)_innerArray[index];
        }
        set
        {
            _innerArray[index] = value;
        }
    }
