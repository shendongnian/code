    public class Update
    {
        public Expression MemberExpression { get; set; }
        public Type ClassType { get; set; }
        public object NewValue { get; set; }
    }
    public class MyType
    {
    	public DateTime? LastModified { get; set; }
    }
    
    void Main()
    {
    	var myUpdate = new Update
    	{
    		MemberExpression = 
                (Expression<Func<MyType, DateTime?>>)((MyType o) => o.LastModified),
            ClassType = typeof(MyType),
    		NewValue = DateTime.Now
    	};
    	
        // At a later point where we do not want to instantiate via strong typing
    	var item = Activator.CreateInstance(myUpdate.ClassType);
    	
    	var lambda = myUpdate.MemberExpression as LambdaExpression;
    	var memberExpr = lambda.Body as MemberExpression;
    	var prop = memberExpr.Member as PropertyInfo;
    	
    	prop.SetValue(item, myUpdate.NewValue);
    	
    	item.Dump();
    }
