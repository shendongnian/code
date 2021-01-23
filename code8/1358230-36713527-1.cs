	var myList = new List<string> { "A" };
	Expression<Func<string, bool>> a = (s) => myList.Contains(s);
	ParseContainsExpression(a.Body as MethodCallExpression);
    private bool ParseContainsExpression(MethodCallExpression expression)
    {
    	expression.Object; //myList
    	expression.Arguments[0]; //s	
    	return false;
    }
