    private void async UpdateEntitiesAsync<T>(IEnumerable<T> entities)
    {
        try
        {
            EntitiesChangedResponse<T> response = await UpdateEntities(entities);
            //asynchronous callback code can go here
        }
        catch(AggregateException ex)
        {
          //handle a thrown exception
        }
    }
