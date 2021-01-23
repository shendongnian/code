    [TestMethod]
    public void Constructor_ExpectInstantiation()
    {
        Mock<OrderController> mockOrderController = new Mock<OrderControler>();
        var checkoutManager = new CheckoutManager(mockOrderController.Object);
    
        Assert.IsNotNull( checkoutManager );
    }
