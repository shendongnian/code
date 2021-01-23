    public class FileChecker
    {
         public bool Exists(string filePath) { }
    }
    
    Checker checker = new Checker();
    Expression<Func<bool>> expr = () => checker.Exists(@"C:\hello.txt");
    
    MethodCallExpression methodCallExpr = (MethodCallExpression)expr.Body;
    MethodInfo calledMethod = methodCallExpr.Method;
    IEnumerable<ParameterInfo> inputParams = calledMethod.GetParameters();
    Type declaringType = calledMethod.DeclaringType;
   
