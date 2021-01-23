    private Mock<ICore> mockCore;
    private IReactorInteractions reactor;
    
    [SetUp]
    public void TestSetup() {
        mockCore = new Mock<ICore>();
        reactor = new ReactorInteractions(mockCore.Object);
    }
