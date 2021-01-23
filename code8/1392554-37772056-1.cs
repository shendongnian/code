    private void async UpdateEntities<T>(IEnumerable<T> entities)
    {
        try
        {
             var task = await UpdateEntitiesAsync(entities);
             // this LOC executes once the task completes 
            //  provided the method did not throw an exception.
           //   It also does not block the calling thread.
        }
        catch(AggregateException ex)
        {
          //handle a thrown exception
        }
    }
    
