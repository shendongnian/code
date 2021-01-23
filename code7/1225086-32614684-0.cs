    [Fact]
    public void MyTest()
    {
        var fixture = new Fixture().Customize(new AutoMoqCustomization());
        var mock = fixture.Freeze<Mock<ISampleUow>>();
        var sut = fixture.Create<SampleService>();
    
        sut.MakeOrder();
    
        mock.Verify(uow => /* assertion expression goes here */);
    }
