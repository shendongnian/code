    [Fact]
    public void CalculateOrderTotalSumTest() 
    {
        // customer id we want to check 
        Guid customerId = new Guid("64f52c5c-44b4-4adc-9760-5a03d6f98354");
        // Our test data
        List<Order> orders = new List<Order>()
        {
            new Order() { Customer = new Guid("64f52c5c-44b4-4adc-9760-5a03d6f98354"), TotalSum = 100.0m),
            new Order() { Customer = new Guid("64f52c5c-44b4-4adc-9760-5a03d6f98354"), TotalSum = 50.0m)
        }
        // Create a mock of the IOrdersRepository
        var ordersRepositoryMock = new Mock<IOrdersRepository>();
        // Next you need to set up the mock to return a certain value
        ordersRepositoryMock
            .Setup( m => m.ordersRepositoryMock(It.Is<Guid>( cId => cId == customerId) )
            .Returns(orders);
        
        decimal totalSum = ordersRepositoryMock.Object.GetAllOrdersTotalSum(customerId);
        Assert.AreEqual(150.0m, totalSum, "Total sum doesn't match expected result of 150.0m");
        ordersRepositoryMock.VerifyAll();
    }
