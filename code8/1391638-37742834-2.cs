    [Conditional("DEBUG")]
    public void SomeMethod(
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "", 
        [CallerLineNumber] int sourceLineNumber = 0)
    {
        Logger.WriteMethodTrace(memberName);
    )
