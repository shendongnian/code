       [TestMethod]
       public void IsOrderShippable_OrderIsShippable_ShouldReturnTrue()
       {
          // you can parametrize this helper method as needed
          var inventoryService = GetMockInventoryServiceWithItemsNotOnHold();
    
          // You can parametrize this helper method with credit line, etc.
          var customerService = GetMockCustomerService(1000m);
    
          // parametrize this method with number of items and total price etc.
          Order order = GetTestOrderWithItems();
    
          OrderManager orderManager = new OrderManager(
             customerService: customerService.Object,
             inventoryService: inventoryService.Object);
    
          bool isShippable = orderManager.IsOrderShippable(order);
    
          Assert.IsTrue(isShippable);
       }
