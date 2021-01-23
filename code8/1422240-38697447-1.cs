    DbContext.OrderItem.Remove(orderItem);
    DbContext.SaveChanges();
    if (DbContext.OrderItem.Count(x => x.OrderId == order.Id) == 0)
    {
        DbContext.Order.Remove(order);
        DbContext.SaveChanges();
    }
