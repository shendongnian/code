    [Test]    
    public void SlowFooTest()
    {    
        IBar bar = Substitute.For<IBar>();
        var foo = new SlowFoo(bar);
        IResult result = foo.ResolveTheProblem(bar);
        Assert.IsNotNull(result);
    }
    [Test]    
    public void FastFooTest()
    {    
        IBar bar = Substitute.For<IBar>();
        var foo = new FastFoo(bar);
        IResult result = foo.ResolveTheProblem(bar);
        Assert.IsNotNull(result);
    }
