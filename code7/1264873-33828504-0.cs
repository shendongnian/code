    public static void RecursivelyCall(this object thisObject, object [] param,  [System.Runtime.CompilerServices.CallerMemberName] string methodName = "")
    {
        Type thisType = thisObject.GetType();
        MethodInfo theMethod = thisType.GetMethod(methodName);
        theMethod.Invoke(thisObject, param);
    }
    public static void RecursivelyCall(this object thisObject, object param, [System.Runtime.CompilerServices.CallerMemberName] string methodName = "")
    {
        Type thisType = thisObject.GetType();
        MethodInfo theMethod = thisType.GetMethod(methodName);
        theMethod.Invoke(thisObject, new object[] {param});
    }
