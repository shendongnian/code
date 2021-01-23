    public void Info(string message, object arg0=null, object arg1=null,
    [CallerMemberName] string memberName = "",[CallerLineNumber] int lineNumber = 0)
    {
        _log.Info(BuildMessage(message, memberName, lineNumber), arg0, arg1);
    }
