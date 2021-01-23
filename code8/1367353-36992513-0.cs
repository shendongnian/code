    interface IMyService<T>
    {
        T Foo();
    }
    class Stateful1 : StatefulService, IMyService<string>
    {
        public Stateful1(StatefulServiceContext context)
            : base(context)
        { }
        public string Foo()
        {
            // do foo
        }
    }
