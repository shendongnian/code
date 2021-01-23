	var myList = new List<string> { "A" };
	Expression<Func<string, bool>> a = (s) => myList.Contains(s);
	ParseContainsExpression(a.Body as MethodCallExpression);
    private bool ParseContainsExpression(MethodCallExpression expression)
    {
    	expression.Object.Dump(); //myList
    	expression.Arguments[0].Dump(); //s	
    	return false;
    }
