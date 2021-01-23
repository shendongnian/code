    // In the main application:
    public dynamic PerformMethodCall(dynamic obj, Func<dynamic, dynamic> method)
    {
        return method(obj);
    {
     // In a mod:
     mainProgram.PerformMethodCall(myDynamicObj, n => n.myDynamicMethod());
     // In another mod:
     mainProgram.PerformMethodCall(myDynamicObj, n => n.anotherMethod());
