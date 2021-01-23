    private IEnumerable<T> CalcProp()
    {
        // Business logic using Name and Values
        return resultOfLogic;
    }
    
    public IEnumerable<T> MyProp 
    {
        get { return _MyProp.Value; }
    }
    private readonly Lazy<IEnumerable<T>> _MyProp;
    
    public MyClass(string Name, IEnumerable<T> Values)
    {
        this._Name = Name;
        this._Values = Values;
        this._MyProp = new Lazy<IEnumerable<T>>(CalcProp);
    }
