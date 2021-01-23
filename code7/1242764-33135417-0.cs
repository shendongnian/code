        try
        {
            return
                await
                Policy.Handle<MongoConnectionException>()
                      .RetryAsync(3,
                          (exception, i) =>
                              {
                                  logger.Warn(exception,
                                      string.Format("Mongo Connection Exception - Retry Count : {0}", i));
                              })
                      .ExecuteAsync(async () => await operation());
        }
        catch (MongoConnectionException ex)
        {
            logger.Error(ex);
            return null;
        }
