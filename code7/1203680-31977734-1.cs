    void Main()
    {
    	var method = something(typeof(MyClass), "propA", "propB");
    	var classes = new List<MyClass>();
    	classes.Add(new MyClass { propA = 1, propB = 2 }); // Should return false
    	classes.Add(new MyClass { propA = 3, propB = 2 }); // Should return true
    	classes.Add(new MyClass { propA = 2, propB = 2 }); // Should return false
    	var res = classes.Where(method);
    	res.Dump();	//Only class with propA = 3 && propB == 2 is returned
    }
    
    private Func<object, bool> something(Type t, string left_element, string right_element)
    {
    	var props = t.GetProperties();
    	return (onObject) => {
    		int left_int;
    		object leftSide;
    		if (!int.TryParse(left_element, out left_int))
    		{
    			leftSide = props.FirstOrDefault (p => p.Name == left_element).GetValue(onObject);
    		} else {
    			leftSide = left_int;
    		}
    		
    		int right_int;
    		object rightSide;
    		if (!int.TryParse(right_element, out right_int))
    		{
    			rightSide = props.FirstOrDefault (p => p.Name == right_element).GetValue(onObject);
    		} else {
    			rightSide = left_int;
    		}
    
    		return Comparer.Default.Compare(leftSide, rightSide) > 0;		
    	};
    }
    
    private class MyClass {
    	public int propA {get;set;}
    	public int propB {get;set;}
    }
