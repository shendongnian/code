    [Theory, TestingSample.AutoData]
    public void FactoryClassIsNotFrozen(
        [Frozen(Matching.ImplementedInterfaces)]Class first,
        FactoryClass second)
    {
        Assert.IsType<FactoryClass>(first); // passes
        Assert.IsType<FactoryClass>(second); // passes
        Assert.Same(first, second); // fails
    }
