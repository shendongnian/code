    /// <summary>
    /// Calls a function's native implementation, then checks if the error code 
    /// is not ErrorCode.Ok.  If it is, throws an AppException.
    /// </summary>
    /// <param name="nativeCall">
    /// A function that returns the status code as an int.
    /// </param>
    private static void CheckErrorCode(Func<int> nativeCall)
    {
        var returnCode = (ErrorCode)nativeCall();
        if(returnCode != ErrorCode.OK)
        {
            throw new AppException(returnCode);
        }
    }
