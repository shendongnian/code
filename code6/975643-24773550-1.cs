    [Fact]
    public void ValidLoginShouldReturnAToken()
    {
      var fixture = new Fixture().Customize(new ConstructorCustomization(typeof(Dummy),
                                            new GreedyConstructorQuery()))
                                 .Customize(new AutoMoqCustomization());
    
      Dummy sut = fixture.Create<Dummy>();
    
    }
