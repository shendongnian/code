    private Task async UpdateEntitiesAsync<T>(IEnumerable<T> entities)
    {
        try
        {
            EntitiesChangedResponse<T> response = await UpdateEntities(entities);
            //asynchronous callback implementation code can go here
        }
        catch(AggregateException ex)
        {
          //handle a thrown exception
        }
    }
