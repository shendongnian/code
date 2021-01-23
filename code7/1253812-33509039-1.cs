    public void Update(Order editedOrder)
    {
        var context = new YourDbContext();
        
        //Get original order from database.
        var originalOrder = context.Orders.Including("OrderDetails").Where(x => x.OrderId == editedOrder.OrderId).FirstOrDefault();
        //Update the value of original order using edited order.
        context.Entry(originalOrder).CurrentValues.SetValues(editedOrder);
        //Find list of added items (Id of added items is 0).
        var addedList = editedOrder
            .OrderDetails
            .Where(y => y.OrderDetailId == 0)
            .ToList();
        //Find list of removed items.
        var deletedList = originalOrder
            .OrderDetails
            .Where
            (
                x =>
                (
                    !editedOrder.OrderDetails
                    .Select(y => y.OrderDetailId)
                    .Contains(x.OrderDetailId)
                )
            )
            .ToList();
        //Find list of edited items.
        var editedList = editedOrder.OrderDetails
            .Where
            (
                y => originalOrder
                .OrderDetails
                .Select(z => z.OrderDetailId)
                .Contains(y.OrderDetailId)
            )
            .ToList();
        //Use a loop over deleted items list and set state of them to removed.
        deletedList.ForEach(deletedDetail =>
        {
            originalOrder.OrderDetails.Remove(deletedDetail);
            context.Entry(editedOrder).State = EntityState.Deleted;
        });
        //Use a loop over edited items list and update value of original order details  that have been loaded in context.
        editedList.ForEach(editedDetail =>
        {
            var originalOrderDetail = originalOrder.OrderDetails.Where(x => x.OrderDetailId == editedDetail.OrderDetailId).FirstOrDefault();
           context.Entry(originalOrderDetail).CurrentValues.SetValues(editedDetail);
        });
        //Use a loop over added items list and set state of them to added.
        addedList.ForEach(addedDetail =>
        {
            originalOrder.OrderDetails.Add(addedDetail);
        });
        //Set the state of original order to modified.
        context.Entry(oroginalOrder).State = System.Data.Entity.EntityState.Modified;
        //Save context changes.
        context.SaveChanges();
    }
