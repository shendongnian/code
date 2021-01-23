    // Get the original selected orders
    IEnumerable<int> originalOrders = delivery.Orders.Select(o => o.OrderID);
    // Get the selected orders from the Edit view
    IEnumerable<int> selectedOrders = model.Orders.Where(o => o.IsSelected).Select(o => o.ID);
    // Get the orders that have been added
    IEnumerable<int> newOrders = selectedOrders.Except(originalOrders);
    // Get the orders that have been deleted
    IEnumerable<int> deletedOrders = originalOrders.Except(selectedOrders);
    foreach (int ID in newOrders)
    {
      // Get the order, set its DeliveryID property and save (as per your existing code)
    }
    IEnumerable<Order> toDelete= db.Orders.Where(o => deletedOrders.Contains(o.OrderID));
    foreach (Order order in toDelete)
    {
      order.DeliveryID = null;
      db.Entry(order).State = EntityState.Modified;
    }
    db.SaveChanges();
