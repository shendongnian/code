    //check item group for duplicates (just as a test)
    var items = db.ItemGroups.Where(x => x.ID == _id); //breakpoint here to make sure there is only one match. If there is only one then you are deleting a linked item to the entity you are deleting.
    
    var itemtoremove = db.ItemGroups.Single(x => x.ID == _id);
    if (itemtoremove != null)
    {
        db.ItemGroups.Remove(itemtoremove);
        db.SaveChanges();
    }
