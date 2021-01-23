    public string MyParam2(MyClass instance) { }
    void MyFunction(MyClass anObject, Func<MyClass, string> aMethod)
    {
        string val = aMethod(anObject);
    }
