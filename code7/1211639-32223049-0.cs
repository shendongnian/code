    public override void OnException(MethodExecutionArgs args)
    {
        // Logging part..
        MethodInfo methodInfo = (MethodInfo)args.Method;
        MethodInfo create = methodInfo.ReturnType.GetMethod(
                        "Create",
                        new[] { typeof(CodeMessage), typeof(MessageType), typeof(Exception) });
        args.ReturnValue = create.Invoke(null, new object[] { CodeMessage.InternalError, MessageType.Error, args.Exception });
        args.FlowBehavior = FlowBehavior.Return;
    }
