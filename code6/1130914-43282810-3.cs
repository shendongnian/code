    public T InvokeMethod <T>(Assembly assembly, string serviceNameToCall, MethodInfo methodToCall)
    {
            SoapHttpClientProtocol mySoapProtocoll;
        try
        {
             object serviceInstance = myAssembly.CreateInstance(serviceNameToCall);
             mySoapProtocoll = (SoapHttpClientProtocol)serviceInstance;
             mySoapProtocoll.Credentials = CredentialCache.DefaultCredentials; // or use your own
             object myObject = (T)ServiceType.InvokeMember(methodToCall, BindingFlags.InvokeMethod, null, mySoapProtocoll, args);
        }
    }
