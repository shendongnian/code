    public static void Main()
    {
    ...
    var returnValue = exec.DoStuff().Result;
    // Or, if there is a SynchronizationContext
    returnValue = Task.Run(() => exec.DoStuff()).Result; // This may prevent dead locks that can occur in previous line
    }
