    class Category
    {
        [...]
        IList<Category> children;
    }
    
    //For instance as global arrays...
    int[] all_categories;
    int[] all_relation;
    List<Category>  sfGetCategoryAllTree(output, id)
    {	
        List<Category> tree;
        //$categories = $sfdb->run("SELECT * FROM $table_category c"'
        //    ORDER BY position ASC", '', true)
        //        ->fetchAll($output);	
    	List<Category> categories = this.Query().Select().ToList();// Assuming this is aquivalent to the above selection statement...
    	
    	foreach (Category c in categories)
    	{		
    		all_categories[c.Id]  
    		if (c.ParentId != 0) // The is no NULL for int, you might want to use the nullable type "int?" or an additional bool isRoot
    		{
    			if (tree == null) tree = new List<Category>();
    			tree.Add(c);
    			all_relation[0] = c.Id;	
    		}else
    		{
    			all_relation[c.ParentId] = c.Id;
    		}
    	}	
    	if (all_relation[0] != 0)
    	{
    		tree = sfSideTree(all_relation[0], all_categories, all_relation);
    	}
    	
    	return tree;//returns the tree, or NULL 
    }
    
    List<Category> sfSideTree (int[] branch, Dictionary<int, Category> categories, int[] relation)
    {
    	List<Category> tree = new List<Category>();
    	if (branch != null)
    	{
    		foreach (var b in branch)
    		{
    			if (relation[b] != null)
    			{
    				
    				categories[b].categories = sdSideTree(relation[b], categories, relation)						
    			} else
    			{
    				categories[b].categories = new List<Category>();
    			}
    			tree = aux;
    		}
    	}
    	return tree;
    }
