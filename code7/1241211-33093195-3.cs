    public ActionResult Create(OrderVM model)
    {
      // Initialize a new Order and map properties from view model
      var order = new Order
      {
        CustomerName = User.Identity.Name,
        OrderDate = DateTime.Now,
        ....
        PaymentMethod = model.PaymentMethod
      }
      // Save the order so that you now have its `ID`
      IEnumerable<int> selectedItems = model.Inventory.Where(i => i.IsSelected);
      foreach(var item in selectedItems)
      {
        // You have not shown the model for this so just guessing
        var orderItem = new OrderItem{ OrderID = order.Id, InventoryId = item };
        db.OrderItems.Add(orderItem);
      }
      db.SaveChanges();
    }
