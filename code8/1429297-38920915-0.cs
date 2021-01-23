    public void GetName_ShouldReturnCorrectId() {
        //Arrange
        var name = "Johnny";
        var expectedId = 1;
        var context = new TestSContext();
        context.Customers.Add(new Customer { c_ID = expectedId, c_Name = name});    
        var controller = new CustomerController(context);
        //Act
        var result = controller.GetCustId(name) as OkNegotiatedContentResult<Customer>;
        //Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(expectedId, result.Content.c_ID);
    }
