    public static DoWork()
    {
       var context = new MyContext();  
    
       List<GenerationEvent > internalEntityType = new List<GenerationEvent ();
       foreach(var item in SomeList)
       {
            var newItemEntity = new GenerationEvent();
            newItemEntity.Name = "Test";
            context.GenerationEvent.Add(newItemEntity);
    
            //add to internal list
            internalEntityType.Add(newItemEntity )
       }
       context.SaveChanges();
    
       var first_id = internalEntityType.FirstOrDefault().Id;
       //first_id will not be 0 it will be the Id the database gave it.
    }
