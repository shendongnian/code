    [Fact]
    public void Customers_IsCorrectlyInitialisedAtStartup_Test()
    {
        var databaseMock = new Mock<IDatabse>();
        var customerMock = new Mock<ICustomer>();
        
        var customers = new [] { customerMock.Object };
        databaseMock.Setup(mock => mock.GetCustomerList())
            .Returns(customers);
        var sut = new CustomerListModel(databaseMock.Object);
        Assert.Equal(customers, sut.Customers);
    }
