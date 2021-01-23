    try
    {
          results = await Policy
                .Handle<WebException>()
                .WaitAndRetryAsync
                (
                    retryCount: 5,
                    sleepDurationProvider: retryAttempt =>  TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                )
                .ExecuteAsync(async () => await task.Invoke());
    }
 
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
    public static class AsyncErrorHandler
    {
        public static void HandleException(Exception ex)
        {
            if (ex is ExceptionToThrowToUser)
            {
               throw;               
            }
            else
                Debug.WriteLine(ex.Message);
        }
    }
