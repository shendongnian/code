    using System.Diagnostics;
    
    public void myMethod()
    {
         StackTrace stackTrace = new StackTrace();
         // get calling method name
         string methodName = stackTrace.GetFrame(0).GetMethod().Name;
    }
