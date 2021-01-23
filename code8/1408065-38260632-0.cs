    public T this[int index]
    {
       // reduced for simplicity
       set { internalArray[index] = value; }
       get { return internalArray[index]; }
    }
