    public T this[int index]
    {
        get
        { // some checks removed 
            return _items[index];
        }
    
        set { _items[index] = value;}
    }
