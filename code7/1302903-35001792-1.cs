    private static void DoStuff(IStagedEntity stagedEntity)
    {
            dynamic se = stagedEntity;
            var properties = stagedEntity.EntityType.GetProperties().ToList();
    
            foreach (var item in se.StagedItems)
            {   
                foreach (var property in properties)
                {
                 // Do something with
                 // property.GetValue( item, null );
                }
            }
    }
