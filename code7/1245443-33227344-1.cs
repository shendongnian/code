    private void DoIt<T>()
    {
        var mock = new Mock<T>();
    	var parameter = Expression.Parameter(typeof(T));
    	var methodInfo = typeof(T).GetMethod("MyMethod"); //Find the method "MyMethod" on type "T"
    	if (methodInfo != null)
    	{
    		var body = Expression.Call(parameter, methodInfo);
    		var lambdaExpression = Expression.Lambda<Func<T, int>>(body, parameter);
            //At this point, lambdaExpression is:
            //Param_0 => Param_0.MyMethod()
    		mock.Setup(lambdaExpression).Returns(0);
    	}
    }
    class MyClass 
    {
    	public int MyMethod() 
    	{
    		return 5;
    	}
    }
