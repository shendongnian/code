    // Create an entity to represent the Entity you wish to delete 
    // Notice you don't need to know all the properties, in this 
    // case just the ID will do. 
    Category stub = new Category { ID = 4 }; 
    // Now attach the category stub object to the "Categories" set. 
    // This puts the Entity into the context in the unchanged state, 
    // This is same state it would have had if you made the query 
    ctx.AttachTo("Categories", stub); 
    // Do the delete the category 
    ctx.DeleteObject(stub); 
    // Apply the delete to the database 
    ctx.SaveChanges();
