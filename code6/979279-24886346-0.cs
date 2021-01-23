    using (RSDContext context = new RSDContext())
    {
        var details = order.OrderDetails;
        order.OrderDetails = null;
    
        context.Entry(order).State = EntityState.Modified;
        foreach (var detail in details)
        {
            // Add.
            if (detail.Id == 0)
            {
                detail.OrderId = order.Id;
                context.Entry(detail).State = EntityState.Added;
            }
            // Update.
            else
            {
                context.Entry(detail).State = EntityState.Modified;
            }
            // How to know which entity to be deleted?
            // context.Entry(detail).State = EntityState.Deleted;
        }
    
        order.OrderDetails = details;
        context.SaveChanges();
    }
