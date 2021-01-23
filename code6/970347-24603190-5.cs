    /// <summary>
    /// Takes the result code from invoking a native function.  If the result is
    /// not ErrorCode.OK, throws an AppException with that error code.
    /// </summary>
    /// <param name="returnCodeInt">
    /// The return code of a native method call, as an integer. 
    /// Will be cast to ErrorCode.
    /// </param>
    private static void CheckErrorCode(int returnCodeInt)
    {
        ErrorCode returnCode = (ErrorCode)returnCodeInt;
        if(returnCode != ErrorCode.OK)
        {
            throw new AppException(returnCode);
        }
    }
    
    public void getSize(out int sz)
    {
        CheckErrorCode(ClibDllFunc3(datap, out sz));
    }
