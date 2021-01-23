    var stackTrace = new StackTrace();
    var i = 0;
    var myType = GetType();
    while (stackTrace.GetFrame(i).GetMethod().IsConstructor 
           && stackTrace.GetFrame(i).GetMethod().DeclaringType.IsAssignableFrom(myType))
    {
        i++;
    }
    var methodCallingTheConstructor = stackTrace.GetFrame(i).GetMethod();
