    public class Update
    {
        public Expression MemberExpression { get; set; }
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
    		NewValue = DateTime.Now
    	};
    	
    	var item = new MyType();
    	
    	var lambda = myUpdate.MemberExpression as LambdaExpression;
    	var memberExpr = lambda.Body as MemberExpression;
    	var prop = memberExpr.Member as PropertyInfo;
    	
    	prop.SetValue(item, myUpdate.NewValue);
    	
    	item.Dump();
    }
