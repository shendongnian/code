    bool Func1(int param1, enum1 type)
    {
         switch (type) {
             case enum1.abc:
             // ...
             break
             // ...
         }
    }
    bool Func2(int param1, enum2 type) { Func1(param1, ToEnum1(type)) }
    
    private static enum1 ToEnum1(enum2 type)
    {
        switch(type)
        {
            case enum2.abc: return enum1.abc;
            // ...
            default: throw new NotImplementedException("missed a case!");
        }
    }
