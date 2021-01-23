    public BaseClass {
        public virtual void DoSomething() {...}
    }
    
    public DerivedClass : BaseClass {
        public override void DoSomething() {...}
    }
    public foo(BaseClass foobar) {
        foobar.DoSomething();    
    }
