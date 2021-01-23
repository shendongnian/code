    [System.Security.SecuritySafeCritical]  // auto-generated
    protected Exception(SerializationInfo info, StreamingContext context) 
    {
     //some validation
        _className = info.GetString("ClassName");
        _message = info.GetString("Message");
        _data = (IDictionary)(info.GetValueNoThrow("Data",typeof(IDictionary)));
        _innerException = (Exception)(info.GetValue("InnerException",typeof(Exception)));
        _helpURL = info.GetString("HelpURL");
        _stackTraceString = info.GetString("StackTraceString");
        _remoteStackTraceString = info.GetString("RemoteStackTraceString");
        _remoteStackIndex = info.GetInt32("RemoteStackIndex");
        _exceptionMethodString = (String)(info.GetValue("ExceptionMethod",typeof(String)));
        HResult = info.GetInt32("HResult");
        _source = info.GetString("Source");
    //some bla bla....
