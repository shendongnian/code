    PM> Install-Package AutoFixture.AutoMoq
    [Fact]
    public void FreezeUsingAutoFixtureAutoMoq()
    {
        var fixture = new Fixture()
            .Customize(new AutoMoqCustomization());
        var expected = fixture.Freeze<Mock<IComponent>>().Object;
        var decorator = fixture.Create<LoggingComponent>(); 
            
        var actual = decorator.Component;
        Assert.Equal(expected, actual);
    }
