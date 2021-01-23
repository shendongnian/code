    public void Info(string message, params object[] args)
    {
      StackFrame callStack = new StackFrame(1, true);
      string memberName = callStack.GetMethod().Name;
      int lineNumber = callStack.GetFileLineNumber();
      _log.Info(BuildMessage(message, memberName, lineNumber), args);
    }
