    // Test whether a string is a certain length
    public Func<string,bool> IsOfCorrectLength(int lengthToTest)
    {
    	var param = Expression.Parameter(typeof(string));
        var test = Expression.Equal(Expression.Property(param, "Length"), Expression.Constant(lengthToTest));
    	return Expression.Lambda<string,bool>(test,param).Compile();
    }
    
    public void DoSomething()
    {
    	var is5CharsLong = IsOfCorrectLength(5);
    	
    	var result = is5CharsLong("Here's a string that would fail");
    }
