    private bool IsRequestTransferred()
    {
        System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace();
        int requestCompletionCount = 0;
        foreach (var stackFrame in stackTrace.GetFrames())
        {
            System.Reflection.MethodBase methodBase = stackFrame.GetMethod();
            if (methodBase.DeclaringType.Name == "UnsafeIISMethods" && methodBase.Name == "MgdIndicateCompletion")
            {
                if (++requestCompletionCount == 2)
                {
                    return true;
                }
            }
        }
        return false;
    }
    
    void Application_Error(object sender, EventArgs e)
    {
        bool isRequestTransferred = IsRequestTransferred();
    }
