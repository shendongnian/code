    public static Map UpdateMap(Map map)
    {
    	// get map in its current state
    	var previousMap = context.Maps
           .Where(m => m.Id == map.Id)
           .Include(m => m.Tags).ToList();
    	
    	// work out tags deleted in the updated map
    	var deletedTags = previousMap.Tags.Except(map.Tags);
    
    	// mark them as deleted
    	deletedTags.ForEach(t = > context.Entry(t)
           .State = EntityState.Delete);
    
    	// .. deal with added tags
    }
