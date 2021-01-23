    class FooContainer
    {
        public FooContainer(Foo originalValue)
        {
            this.Value = originalValue;
        }
        public Foo Value { get; set; }
    }
    // ...
    builder.RegisterType<FooContainer>().SingleInstance();
    builder.Register(c => c.Resolve<FooContainer>().Value).As<Foo>();
    // ...
    c.Resolve<FooContainer>().Value = new Foo(); 
