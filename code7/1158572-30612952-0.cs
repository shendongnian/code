    var realFoo = new Ninject.Kernel(new MyExampleModule()).Get<IFoo>();
    var mockFoo = MockRepository.GenerateStub<IFoo>();
    mockFoo.Stub(f => f.Method2()).Return(42);
    mockFoo.Stub(f => f.Method1())
       .WhenCalled(invocation =>
       {
           invocation.ReturnValue = realFoo.Method2();
       })
       .Return(whateverValue);
