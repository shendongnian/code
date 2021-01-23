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
            else
            {
               // Deleted
               if (detail.NotMapped_IsDeleted) // Ui needs to mark this property as true for deleted items
               {
                  context.Entry(detail).State = EntityState.Deleted;
               }
               else
               {
                  context.Entry(detail).State = EntityState.Modified;
               }
            }
        }
    
        order.OrderDetails = details;
        context.SaveChanges();
    }
