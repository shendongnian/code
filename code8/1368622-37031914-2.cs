    void TestExceptionMessage(Expression<Action> expression, string message)
    {
        try
        {
            var methodName = (expression.Body as MethodCallExpression)?.Method.Name;
            if (methodName != null) 
            { 
                Debug.WriteLine($"Calling {methodName}");
            }
            expression.Compile().Invoke();
            Assert.Fail("No exception thrown");
        }
        catch (ApplicationException e)
        {
            StringAssert.StartsWith(e.Message, message);
        }
    } 
