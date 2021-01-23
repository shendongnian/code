    private Expression<Func<Genre,bool>> CreateExpression(params Expression<Func<Object>>[] selectors)
    {
    	//We are working on a Genre type, and make a parameter of it
    	//Query so far looks like g =>
    	var param = Expression.Parameter(typeof(Genre),"g");
    	
    	//Set the base expression to make it easy to build
    	//Query so far looks like g => true
    	Expression expression = Expression.Constant(true);
    	
    	foreach(var selector in selectors) {
    		//Find out the name of the variable was passed
    		var selectorname = TestExtension.nameof(selector);
    		//Get the value
    		var selectorValue = selector.Compile()();
    		
    		//Create an accessor to the genre (g.Language for example)
    		var accessMethod = Expression.PropertyOrField(param, selectorname);
    		
    		//Check if it equals the value (g.Language == "en")
    		var equalExpr = Expression.Equal(accessMethod, Expression.Constant(selectorValue));
    		
    		//Make it an And expression
    		//Query so far looks like g => true && g.Language == "en"
    		expression = Expression.AndAlso(expression, equalExpr);
    		//Second pass through the loop would build:
            //g => true && g.Language == "en" && g.Name == "comedy"
    	}
    	
    	//Turn it into a lambda func and cast it
    	var result = Expression.Lambda(expression, param) as Expression<Func<Genre, bool>>;
    	return result;
    }
    
    public class Genre
    {
        public string Language { get; set; }
        public string Name { get; set; }
    }
    
    //Taken from my answer at http://stackoverflow.com/a/31262225/563532
    
    public static class TestExtension
    {
        public static String nameof<T>(Expression<Func<T>> accessor)
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
