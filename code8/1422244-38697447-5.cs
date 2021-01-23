    DbContext.OrderItem.Remove(orderItem);
    DbContext.SaveChanges();
    if (!DbContext.OrderItem.Any(x => x.OrderId == order.Id))
    {
        DbContext.Order.Remove(order);
        DbContext.SaveChanges();
    }
