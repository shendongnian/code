    public static Map UpdateMap(Map map)
    {
    	// get map in its current state
    	var previousMap = context.Maps
           .Where(m => m.Id == map.Id)
           .Include(m => m.Tags).ToList();
    	
    	// work out tags deleted in the updated map
    	var deletedTags = previousMap.Tags.Except(map.Tags).ToList();
    
    	// remove the references to removed tags
        deletedTags.ForEach(t => previousMap.Tags.Remove(t));
    
    	// .. deal with added tags
        // very similar code to deleted so not showing
        
        context.SaveChanges();
    }
