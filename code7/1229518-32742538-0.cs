    void Main()
    {
    	AddActions(10);
    
    	var closure1 = functions[0]();
    	var closure2 = functions[1]();
    	
    	Console.WriteLine(object.ReferenceEquals(closure1, closure2));
    	// False
    }
    
    public static void AddActions(int count)
    {
    	for (int i = 0; i < count; i++)
    	{
    		int j = i;
    		functions.Add(delegate()
    		{
    			Console.WriteLine(j);
    			Expression<Func<int>> exp = () => j;
    			Console.WriteLine(exp.ToString());
    			var m = (MemberExpression)exp.Body;
    			var c = (ConstantExpression)m.Expression;
    			Console.WriteLine(c.Value.ToString());
    			return c.Value;
    		});
    	}
    }
    
    public static List<Func<object>> functions = new List<Func<object>>();
