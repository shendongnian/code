    PM> Install-Package AutoFixture.Xunit
    PM> Install-Package AutoFixture.AutoMoq
    
    [Theory, TestConventions]
    public void UsingAutoFixtureAutoMoqWithXunitTheories(
        [Frozen]Mock<IComponent> inner,
        LoggingComponent decorator)
    {
        var expected = inner.Object;
        var actual = decorator.Component;
        Assert.Equal(expected, actual);
    }
