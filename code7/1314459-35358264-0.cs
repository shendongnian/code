    try
    {
        using (MyEntities context = new MyEntities ())
        {
            // do your code
            MyConfiguration.SuspendExecutionStrategy = true;
            context.Entity.Add(entity);
            context.SaveChanges();
        }
    }
    catch (Exception ex)
    {
        logger.Warn("Connection error with database server.", ex);
    }
    finally
    {
        //Enable retries again...
        MyConfiguration.SuspendExecutionStrategy = false;
    }
