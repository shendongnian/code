    public static void SaveCombiners()
    {
    	using (var db = new IP_dbEntities())
    	{
    		db.COMBINERs.RemoveRange(db.COMBINERs);
    		// ... code..
    		db.COMBINERs.AddRange(list);
    		
    		db.BulkSaveChanges();
    	}
    }
