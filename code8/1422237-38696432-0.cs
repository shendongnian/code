    var id = "2";
    var orderItem = db.OrderItems.SingleOrDefault(item => item.Id == id);
    
    if(orderItem != null)
    {
        // The items exists. So we remove it and calling 
        // the db.SaveChanges this will be removed from the database.
        db.OrderItems.Remove(orderItem);
        db.SaveChanges();
        refreshGrid();
    }
    else {
        // Replace orderItem.Id with identifying order item property.
        Console.WriteLine(
            String.Format("Attempted to remove order {0}, but it could not be found.", orderItem.Id)
        );
    }
