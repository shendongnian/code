    if (!_db.Items.Any(x => x.EntityId == requestItem.EntityId &&                            
                                x.UserId == request.UserId))
    {
        // item does not exist, so create it.
        var item = new Item(); 
        // set some properties here...
    
        _db.Items.Add(item);
    }
