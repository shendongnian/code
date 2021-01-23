    public Item DeepCloneItem(Item item)
    {
    	Item itemClone = db.Items.FirstOrDefault(i => i.ItemID == item.ItemID);
    	deepClone(itemClone);
    	db.SaveChanges();
    	return itemClone;
    }
    
    private void deepClone(Item itemClone)
    {
    	foreach (Item child in itemClone.ChildrenItems)
    	{
    		deepClone(child);
    	}
    	foreach(Parameter param in itemClone.Parameters)
    	{
    		db.Entry(param).State = EntityState.Added;
    	}
    	db.Entry(itemClone).State = EntityState.Added;
    }
