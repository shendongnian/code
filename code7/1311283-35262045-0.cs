    public interface ISomeInterface
    {
        string Foo { get; }
        void Bar();
    }
    public interface ISomeInterfaceControl
    {
        ISomeInterface SomeInterface { get; }
    }
