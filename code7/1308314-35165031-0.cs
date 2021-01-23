    public static class UtilExtensions
    {
        public static TResult Execute<TResult>(this Func<TResult> function)
        {
            // do logging
            try
            {
                TResult result = function();
                return result;
            }
            catch (Exception ex)
            {
                // do other stuff ... like logging, handle Retry logic, etc.
            }
            // or throw - this right here could prove unpredictable and is verrrry dirty
            return default(TResult);
        }
    }
    
