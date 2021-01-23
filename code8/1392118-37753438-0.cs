        var stackFrame = new StackFrame(1);
        var callerMethod = stackFrame.GetMethod();
        var callingClass = callerMethod.DeclaringType; // <-- this should be your calling class
        if(callingClass = typeof(myClass))
        {
           // do whatever
        }
