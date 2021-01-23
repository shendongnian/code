    public static T AttemptsAt<T>(this int maxAttempts, Func<T> func)
    {
        for (int i = 0; i < maxAttempts; i++)
        {
            try
            {
                return func();
            }
            catch
            {
    
            }
        }
        throw new Exception("Retries failed.");
    }
