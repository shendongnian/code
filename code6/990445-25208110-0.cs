    func1(int param1, enum1 type)
    {
        if (type.Equals(enum1.abc))
        {
            doSomethingAbc(param1);
        }
        else if(type.Equals(enum1.def))
        {
            doSomethingDef(param1);
        }
    }
    
    
    func2(int param1, enum2 type)
    {
        if (type.Equals(enum2.abc))
        {
            doSomethingAbc(param1);
        }
        else if(type.Equals(enum2.def))
        {
            doSomethingDef(param1);
        }
    }
    private void doSomethingAbc(int param1) { ... }
    private void doSomethingDef(int param1) { ... }
