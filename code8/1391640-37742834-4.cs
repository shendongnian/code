    [Conditional("DEBUG")]
    public void LogMethodNameInDebug(
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "", 
        [CallerLineNumber] int sourceLineNumber = 0)
    {
        Logger.WriteMethodTrace(memberName);
    )
    public void SomeMethod()
    {
        LogMethodNameInDebug(); // don't fillin the methodnames yourself, the compiler will do.
    }
