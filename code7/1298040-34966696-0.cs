    [Theory, TestingSample.AutoData]
    public void ImplementedInterfaces(
        [Frozen(Matching.ImplementedInterfaces)]Class first,
        IInterface second)
    {
        Assert.IsType<FactoryClass>(first); // passes
        Assert.Same(first, second); // fails
    }
