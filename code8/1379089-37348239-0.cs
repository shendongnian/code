    var stackTrace = new StackTrace();
    string lastCSharpMethodName = null;
    for (int i = 0;; i++)
    {
        if (stackTrace.GetFrame(i).GetILOffset() == StackFrame.OFFSET_UNKNOWN)
            break;
        lastCSharpMethodName = stackTrace.GetFrame(i).GetMethod().Name;
    }
    Console.WriteLine(lastCSharpMethodName);
