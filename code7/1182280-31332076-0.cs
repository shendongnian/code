    void Main()
    {
    	List<String> dummy1 = new List<String>();
    	List<String> dummy2 = new List<String>();
    	List<String> dummy3 = new List<String>();
    	List<String> dummy4 = new List<String>();
    	
    	var _d = new Dictionary<int, Expression<Func<List<String>>>>()
    	{
    		{1, () => dummy1},
    		{2, () => dummy2}, 
    		{3, () => dummy3}, 
    		{4, () => dummy4}, 
    	};
    	foreach(var kvp in _d)
    	{
    		MessageBox.Show(kvp.Value.nameof());
    	}
    }
    
    // Define other methods and classes here
    public static class TestExtension
    {
        public static String nameof<T>(this Expression<Func<T>> accessor)
        {
            return nameof(accessor.Body);
        }
    
        public static String nameof<T, TT>(this T obj, Expression<Func<T, TT>> propertyAccessor)
        {
            return nameof(propertyAccessor.Body);
        }
    
        private static String nameof(Expression expression)
        {
            if (expression.NodeType == ExpressionType.MemberAccess)
            {
                var memberExpression = expression as MemberExpression;
                if (memberExpression == null)
                    return null;
                return memberExpression.Member.Name;
            }
            return null;
        }
    }
