    var g = db.Gifts.Find( gift.Id );
    if( null == g )
    {
        // entity not found
    }
    else
    {
        g.Name = gift.Name;
        // repeat with all editable properties
    }
    
    db.SaveChanges();
