    private void async UpdateEntities<T>(IEnumerable<T> entities)
    {
        try
        {
                EntitiesChangedResponse<T> response = await UpdateEntitiesAsync(entities);
             // the await statement continues once the task completes,
            //  and will execute the following LOC.
           //   provided that the task did not throw an exception.
          //    calling this method does not block the calling thread.
         //     The method returns once it hits the await statement.
        }
        catch(AggregateException ex)
        {
          //handle a thrown exception
        }
    }
    
