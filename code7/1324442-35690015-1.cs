    [Export( typeof( IFactory<MyClass> ) )]
    public class Factory : IFactory<MyClass>
    {
        public MyClass Create() => new MyClass();
    }
