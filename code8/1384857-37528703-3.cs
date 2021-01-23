    interface IOwnable
    {
        Base Owner { get; }
    }
    class Foo: IOwnable
    {
        Base IOwnable.Owner { get; }
    }
    class Bar: Foo
    {
        Derived Owner { get { return ((IOwnable)base).Owner as Derived; } // where Derived: Base
    }
