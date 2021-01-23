    public IReadOnlyA DoStuff()
    {
         return new A();
    }
    
    IReadOnlyA a = DoStuff();
    
    // OK! IReadOnly.StringList is IImmutableList<string>
    IImmutableList<string> stringList = a.StringList;
