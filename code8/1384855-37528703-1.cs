    interface ISomeProperty
    {
        Base SomeProperty { get; }
    }
    class Foo: ISomeProperty
    {
        Base ISomeProperty.SomeProperty { get; }
    }
    class Bar: Foo
    {
        Derived SomeProperty { get { return ((ISomeProperty)base).SomeProperty as Derived; } // where Dervided: Base
    }
