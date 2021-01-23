    private static SqlCeLockTimeoutException CreateSqlCeLockTimeoutExceptionForTest()
    {
        var info = new SerializationInfo(typeof (TestableSqlCeLockTimeoutException), 
                   new FormatterConverter());
        info.AddValue("ClassName", string.Empty);
        info.AddValue("Message", string.Empty);
        info.AddValue("InnerException", new ArgumentException());
        info.AddValue("HelpURL", string.Empty);
        info.AddValue("StackTraceString", string.Empty);
        info.AddValue("RemoteStackTraceString", string.Empty);
        info.AddValue("RemoteStackIndex", 0);
        info.AddValue("ExceptionMethod", string.Empty);
        info.AddValue("HResult", 1);
        info.AddValue("Source", string.Empty);
        BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Instance;
        CultureInfo culture = null; // use InvariantCulture or other if you prefer
        object instantiatedType = Activator.CreateInstance(typeof (SqlCeErrorCollection), 
                                    flags, null, null, culture);
        info.AddValue("__Errors__", instantiatedType);
        return new TestableSqlCeLockTimeoutException(info, new StreamingContext());
    }
