    DbContext.OrderItem.Remove(orderItem); // [1]
    if (DbContext.OrderItem.Count(x => x.OrderId == order.Id) == 0) // [2]
    {
        DbContext.Order.Remove(order);
    }
    DbContext.SaveChanges(); // [3]
