    // C#, all versions
    private readonly int _foo;
    public int Foo
    {
        get { return _foo; }
    }
    
    // C#, version 6+
    // actually, this is the same as above, but backing field is generated 
    // for you by compiler
    public int Foo { get; }
