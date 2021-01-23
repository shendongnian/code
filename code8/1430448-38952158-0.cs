    public class ExceptionHandler
    {
        // exposes the last caught exception
        public Exception CaughtException { get; private set; }
        // allows a quick check to see if an exception was caught
        // e.g. if (ExceptionHandler.HasCaughtException) {... do something...}
        public bool HasCaughtException { get; private set; }
        // perform an action and catch any expected exceptions
        public void TryAction(Action action, params Type[] catchableExceptionTypes)
        {
            Reset();
            try
            {
                action();
            }
            catch (Exception exception)
            {
                if (ExceptionIsCatchable(exception, catchableExceptionTypes))
                {
                    return;
                }
                throw;
            }
        }
        // perform a function and catch any expected exceptions
        // if an exception is caught, this returns null
        public T TryFunction<T>(Func<T> function,  params Type[] catchableExceptionTypes) where T : class
        {
            Reset();
            try
            {
                return function();
            }
            catch (Exception exception)
            {
                if (ExceptionIsCatchable(exception, catchableExceptionTypes))
                {
                    return null;
                }
                throw;
            }
        }
        bool ExceptionIsCatchable(Exception caughtException, params Type[] catchableExceptionTypes)
        {
            for (var i = 0; i < catchableExceptionTypes.Length; i++)
            {
                var catchableExceptionType = catchableExceptionTypes[i];
                if (!IsAssignableFrom(caughtException, catchableExceptionType)) continue;
                CaughtException = caughtException;
                HasCaughtException = true;
                return true;
            }
            return false;
        }
        static bool IsAssignableFrom(Exception exception, Type type)
        {
            if (exception.GetType() == type) return true;
            var baseType = exception.GetType().BaseType;
            while (baseType != null)
            {
                if (baseType == type) return true;
                baseType = baseType.BaseType;
            }
            return false;
        }
        void Reset()
        {
            CaughtException = null;
            HasCaughtException = false;
        }
    }
