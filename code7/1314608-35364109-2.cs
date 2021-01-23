    private void LogStep(Delegate action)
    {
        var attr = (TestStepAttribute)Attribute
            .GetCustomAttribute(action.Method, typeof(TestStepAttribute));
        Console.WriteLine("LogStep(Delegate action):  " + attr?.Description);
    }
    private void LogStep(Expression<Action> actionExpr)
    {
        string descr = null;
        var methodCall = actionExpr.Body as MethodCallExpression;
        if (methodCall != null) {
            var attribs = methodCall.Method.GetCustomAttributes(typeof(TestStepAttribute), true);
            if (attribs.Length > 0) {
                descr = ((TestStepAttribute)attribs[0]).Description;
            }
        }
        Console.WriteLine("LogStep(Expression<Action> actionExpr):  " + descr);
    }
