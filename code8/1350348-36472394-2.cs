    [SetUp]
    public void TestInit()
    {
        Mock<IFoo> mock = new Mock<IFoo>();
        builder.RegisterInstance(mock.object).As<IFoo>();
        ...
        ...
        _target = builder.Resolve<The component>();
    }
