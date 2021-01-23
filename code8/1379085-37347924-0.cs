    private static string GetInitialCaller()
    {
        StackTrace trace = new StackTrace();
        StackFrame frame = trace.GetFrames()?.LastOrDefault();
        retrun frame?.GetMethod()?.Name;
    }
