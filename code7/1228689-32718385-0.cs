    public string MyParam2(MyClass instance) { }
    void MyFunction(MyClass anObject, Func<string, MyClass> aMethod)
    {
        string val = aMethod(anObject);
    }
