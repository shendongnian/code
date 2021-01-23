    public long Value
    {
    	get { return _value; }
    }
    
    public int Timestamp
    {
    	get { return (int)(_value >> 32); }
    }
