    public override IMessage Invoke(IMessage msg)
    {
        var methodCall = (IMethodCallMessage)msg;
        var method = (MethodInfo)methodCall.MethodBase;
        string methodName = method.Name;
        string className = method.DeclaringType.Name;
        //return directly methods inherited from Object
        if (method.DeclaringType.Name.Equals("Object"))
        {
            var result = method.Invoke(_instance, methodCall.Args);
            return new ReturnMessage(result, null, 0, methodCall.LogicalCallContext, methodCall);
        }
        var logContext = _logger.DebugTiming("[{0}] Execution time for {1}", className, methodName);
        bool disposeLogContext = true;
        try
        {
            _logger.DebugFormat("[{0}] Call method {1}", className, methodName);
            //execute the method
            //var result = method.Invoke(_instance, methodCall.Args);
            object[] arg = methodCall.Args.Clone() as object[];
            var result = method.Invoke(_instance, arg);
            //wait the task ends before log the timing
            if (result is Task) {
                disposeLogContext = false;
                ((Task)result).ContinueWith(() => logContext.Dispose());
            }
            return new ReturnMessage(result, arg, 0, methodCall.LogicalCallContext, methodCall);
        }
        finally
        {
            if (disposeLogContext)
                logContext.Dispose();
        }
    }
