    public class Program
    {
        public static void Main(string[] args)
        {
            Expression<Func<TheObject, int, bool>> myExpression = (myObj, theType) => myObj.Prop > theType;
    
            int value = 123;
    
            var body = myExpression.Body;
    
            var body2 = new SimpleExpressionReplacer(myExpression.Parameters[1], Expression.Constant(value)).Visit(body);
    
            Expression<Func<TheObject, bool>> myExpression2 = Expression.Lambda<Func<TheObject, bool>>(body2, myExpression.Parameters[0]);
        }
    }
