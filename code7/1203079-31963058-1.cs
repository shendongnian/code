        var stackFrames = new StackTrace().GetFrames();
        var callingframe = stackFrames.ElementAt(1);
        var method = callingframe .GetMethod().Name;
        // Store in log4net ThreadContext:
        ThreadContext.Properties["method "] = method ;
    Then in the layout reference the property:
        Method: %property{method}
    
