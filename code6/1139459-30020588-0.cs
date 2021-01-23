    interface ISomeInterface
    {
        void M1();
        string P1 { get; }
    }
    struct MyStruct : ISomeInterface { /* ... */ }
    void Method<T>(T t) where T : ISomeInterface
    {
        // can call M1:
        t.M1();
        // can get property value P1:
        string text = t.P1;
    }
