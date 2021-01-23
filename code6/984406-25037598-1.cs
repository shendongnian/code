    // load the assembly
    Assembly LogDll = Assembly.LoadFile(@"Log.dll");
    // get the type of the Log class
    Type LogType = LogDll.GetType("logger.Log");
    // get instance of the Log class
    object LogInstance = Activator.CreateInstance(LogType);
    // invoke class member "Log()"
    LogType.InvokeMember("Log",
                            BindingFlags.InvokeMethod | 
                            BindingFlags.Instance | 
                            BindingFlags.Public,
                            null, 
                            LogInstance, 
                            null);
