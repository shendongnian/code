    [Fact]
    public void FactMethodName()
    {
        var kernel = new StandardKernel();
        var foo = new Foo();
        RegisterConstantAsAllTypes(kernel, foo);
        kernel.Get<IFoo>().Should().Be(foo);
        kernel.Get<Foo>().Should().Be(foo);
        kernel.Get<AbstractFoo>().Should().Be(foo);
    }
