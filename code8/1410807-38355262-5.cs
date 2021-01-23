    foreach (IEnumerable<users> batch in usersQuery.Batch(BatchSize))
    {
    	// Retrieve all users for the batch at once.
       var list = batch.Select(x => x.user_id).ToList();
       var userDatas = _oldDb.userData
    						 .AsNoTracking()
    						 .Where(x => list.Contains(x.user_id))
    						 .ToList();	
    
    	// Create list used for BulkInsert		
    	var newDatas = new List<newData>();
    	var newDataItems = new List<Item();
    	
    	foreach(var userData in userDatas)
    	{
    		// newDatas.Add(newData);
    		
    		// newDataItem.OwnerData = newData;
    		// newDataItems.Add(newDataItem);
    	}
    	
    	var context = new UserContext();
    	context.userDatas.AddRange(newDatas);
    	context.userDataItems.AddRange(newDataItems);
    	context.BulkSaveChanges();
    }
