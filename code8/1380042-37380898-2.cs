       // Scenario 1: Return false if the order's value is 
       // greater than the customer's credit limit
       [TestMethod]
       public void IsOrderShippable_OrderValueGreaterThanCustomerCreditLimit_ShouldReturnFalse()
       {
          // Setup the customer's credit limit
          var customerService = new Mock<ICustomerService>();
          customerService.Setup(e => e.GetCreditLimit(It.IsAny<string>())).Returns(1000m);
    
          // Create the order with value greater than credit limit
          var order = new Order { Value = 1001m };
    
          var orderManager = new OrderManager(
             customerService: customerService.Object,
             inventoryService: new Mock<IInventoryService>().Object);
    
          bool isShippable = orderManager.IsOrderShippable(order);
    
          Assert.IsFalse(isShippable);
       }
