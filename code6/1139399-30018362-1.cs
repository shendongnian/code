    var selectedOrderLine = (OrderLine)dgvOrderLine.SelectedRows[0].DataBoundItem;
    // Here using the context class we try to find if there is the 
    // selected item at all 
    var orderLine = db.OrderLines.SingleOrDefault(item=>item.Id == selectedOrderLine.Id);
    if(orderLine!=null)
    {
        // The items exists. So we remove it and calling 
        // the db.SaveChanges this will be removed from the database.
        db.OrderLines.Remove(orderLine);
        db.SaveChanges();
        refreshGrid();
    }
