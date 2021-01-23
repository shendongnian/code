    using (var context = new MyContext()) //passing in optional connection string.
    {
        LIst<EntityType> listOfChangedEntities = //ToDo:either passed in or generated
        context.EntityType.AddRandge(listOfChangedEntities);
        context.SaveChanges();
    
        //after SaveChanges has been done all the entities in the 
        //listOfChangedEntities will now have there id's
        //for update, fetch the entities... change them and Update them
 
    }
