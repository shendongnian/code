    using (RSDContext context = new RSDContext())
    {
        var details = order.OrderDetails;
        order.OrderDetails = null;
    
        context.Entry(order).State = EntityState.Modified;
        foreach (var detail in details)
        {
            if (detail.Id == 0)
            {
                // Adds.
                detail.OrderId = order.Id;
                context.Entry(detail).State = EntityState.Added;
            }
            else if (detail.IsDeleted)
            // Adds new property called 'IsDeleted' 
            //  and add [NotMapped] attribute 
            //  then mark this property as true from the UI for deleted items.
            {
               // Deletes.
               context.Entry(detail).State = EntityState.Deleted;
            }
            else
            {
               // Updates.
               context.Entry(detail).State = EntityState.Modified;
            }
        }
    
        order.OrderDetails = details;
        context.SaveChanges();
    }
