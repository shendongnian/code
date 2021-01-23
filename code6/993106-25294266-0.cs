    // get the parent Ids
    var parentIds = session.Query<Parent>().Select(c => c.Id).ToList(); 
    
    // get the childNames
    var childNames = session.Query<Child>()
    					    .Where(x => parentIds.Contains(x.ParentId)) // get on the child from parents query
    						.Select(x => new {x.Name, x.ParentId}) // get only the properties you need
    						.ToList(); // list of anon objects
    
    // loop in memory between parentIds filling the corresponding childNames
    var result = parentIds.Select(parentId => new ParentDTO() 
    			 { 
    				Id = parentId,
    				ChildrenNames = childNames.Where(x => x.ParentId == parentId).ToList()
    			 }).ToList();
						
						
