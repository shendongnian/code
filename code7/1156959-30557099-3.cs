    [Conditional("DEBUG"), __DynamicallyInvokable]
    public static void Assert(bool condition)
    {
        TraceInternal.Assert(condition);
    }
