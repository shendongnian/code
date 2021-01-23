    private Object setMyPropertyLock = new Object()
    
    public int MyProperty
    {
        get { return _myProperty; }
        set
        {
            lock(setMyPropertyLock)
            {
                _myProperty = value;
                Do1();
                Do2();
            }
        }
    }
