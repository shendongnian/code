    private static object lockObject = new object();
    public static string ConcatLogKeyWithExceptionMessage<T>(this T entity, string configuredLogKeys, bool logOnlySingleKey, string exceptionMessage, bool firstInvocation = true) where T : class
    {
        lock(lockObject )
        {
            // rest of your code here
        }
    }
