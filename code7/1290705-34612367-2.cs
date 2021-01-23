    [TestMethod]
    public void WillUpdateCustomer()
    {
        var mockContext = new Mock<DbContext>();
        var dbCustomer = new Customer { Id = 7 }; // add other properties too
        mockContext.Setup(m => m.Customers).Returns(new [] {dbCustomer}.AsQueryable());
        mockContext.Setup(m => m.SaveChanges()).Returns(1);
        var service = new CustomerService(mockContext.Object);
        var newCustomer = new Customer { Id = 7 }; // Have different properties
        service.UpdateCustomer(newCustomer);
        // Having dbCustomer in here might not be right. I'm thinking reference
        // as opposed to the values being equal on the object used in the call.
        mockContext.Verify(m => m.Update(dbCustomer), Times.Once());
    }
