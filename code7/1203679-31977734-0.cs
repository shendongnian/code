    void Main()
    {
    	var method = something("propA", "propB");
    	var res = method(new MyClass { propA = 3, propB = 2});
    	res.Dump();
    	
    }
    
    private Func<MyClass, bool> something(string left_element, string right_element)
    {
    	Expression leftFunc, rightFunc;
    	var x = Expression.Parameter(typeof(MyClass));
    	if (left_element.All(char.IsDigit)) leftFunc = Expression.Constant(int.Parse(left_element));
    		else leftFunc = Expression.PropertyOrField(x, left_element);
    	if (right_element.All(char.IsDigit)) rightFunc = Expression.Constant(int.Parse(right_element));
    		else rightFunc = Expression.PropertyOrField(x, right_element);
    	
    	var result = Expression.Lambda<Func<MyClass, bool>>(Expression.GreaterThan(leftFunc, rightFunc), x); //exception thrown on this line
    	return result.Compile();
    }
    
    private class MyClass {
    	public int propA {get;set;}
    	public int propB {get;set;}
    }
