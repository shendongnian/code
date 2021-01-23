    public static Task<object> ExecuteAsync(
        MethodInfo actionMethodInfo,
        object instance,
        object[] orderedActionArguments)
    {
        object invocationResult = null;
        try
        {
            invocationResult = actionMethodInfo.Invoke(instance, orderedActionArguments); // !!!
        }
        catch (TargetInvocationException targetInvocationException)
        {
            // Capturing the exception and the original callstack and rethrow for external exception handlers.
            var exceptionDispatchInfo = ExceptionDispatchInfo.Capture(targetInvocationException.InnerException);
            exceptionDispatchInfo.Throw();
        }
        return CoerceResultToTaskAsync(
            invocationResult,
            actionMethodInfo.ReturnType,
            actionMethodInfo.Name,
            actionMethodInfo.DeclaringType);
    }
