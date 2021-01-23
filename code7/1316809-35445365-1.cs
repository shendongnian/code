    private Mock<ICore> mockCore;
    private IReactorInteractions reactor;
    
    [SetUp] // mmm nunit
    public void TestSetup() {
        mockCore = new Mock<ICore>();
        reactor = new ReactorInteractions(mockCore.Object);
    }
