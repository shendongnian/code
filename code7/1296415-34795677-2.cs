    [Theory, AutoMoqDataAttributeGreedy]
    public void SomeTest(
        [Frozen]Mock<IInterface1> mock1,
        [Frozen]Mock<IInterface2> mock2,
        [Frozen(Matching.ImplementedInterfaces)]IInterface3TestImplementation impl3,
        Sut sut)
    {
    }
