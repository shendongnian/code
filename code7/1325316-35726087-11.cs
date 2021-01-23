    [Fact]
    public void Customers_IsCorrectlyInitialisedAtStartup_Test()
    {
        var databaseMock = new Mock<IDatabse>();
        var customer = new Customer();
        
        var customers = new [] { customer };
        databaseMock.Setup(mock => mock.GetCustomerList())
            .Returns(customers);
        var sut = new CustomerListModel(databaseMock.Object);
        Assert.Equal(customers, sut.Customers);
    }
