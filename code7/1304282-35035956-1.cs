    private readonly string myProp;
    public string MyProp { get { return myProp; } }
    protected MyClass(string myProp, ...)
    {
        this.myProp = myProp;
        ...
    }
