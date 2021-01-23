    public void SaveAll(IList<CoreEntity> entitaCoreList)
    {
        bool result = false;
    
        using (var context = new NSTEntities())
        {
    		// ... code ...
    
            context.BulkSaveChanges();
        }
    }
