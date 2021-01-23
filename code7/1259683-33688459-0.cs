    [Theory, AutoData]
    public void Test(
        [Frozen(Matching.ImplementedInterfaces)]Class implementation,
        IInterface @interface)
    {
        Assert.Same(implementation, @interface);
    }
