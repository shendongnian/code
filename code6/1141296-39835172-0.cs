    ///Declarations
    private Mock<IPremiumAdjustmentFinalised > _mockEvent = new Mock<IPremiumAdjustmentFinalised >();
    private readonly Mock<IBus> _mockBus = new Mock<IBus>();
    private SomeEventPublisher _someEventPublisher;
    
    [SetUp]
    public void Setup()
    {
    	 //Instruct moq to set up implementations for the event interface's properties.
    	_mockEvent.SetupAllProperties();
    		
    	_mockBus.Setup(b => b.Publish(It.IsAny<Action<IPremiumAdjustmentFinalised>>()))
    	.Callback((Action<IPremiumAdjustmentFinalised> messageConstructor) =>
    	{
    		//Execute the constructor provided in the action in the event publisher, so the event data can be interrogated.
    		messageConstructor(_mockEvent.Object);
    	});
    	
    	_someEventPublisher = new SomeEventPublisher(_mockBus);
    }
    
    
    [Test]
    public void SomeEventPublisherTest()
    {
    	_someEventPublisher.PublishSomeEvent(AdjustmentAmount, LastModifiedOn, PolicyNumber)
    
    	Assert.AreEqual(_mockEvent.Object.Amount, AdjustmentAmount);
    	Assert.AreEqual(_mockEvent.Object.FinalisedOn, LastModifiedOn);
    	Assert.AreEqual(_mockEvent.Object.PolicyNumber, PolicyNumber);
    }
