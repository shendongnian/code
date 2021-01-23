    public static class ExpressionHelper {
       //we create a Dictionary to manage the comparison operators, 
       //which will probably make things easier when calling the main method.
       public static Dictionary<string, ExpressionType> Comparators = new Dictionary<string, ExpressionType>
            {
                {">", ExpressionType.GreaterThan},
                {">=", ExpressionType.GreaterThanOrEqual},
                {"<", ExpressionType.LessThan},
                {"<=", ExpressionType.LessThanOrEqual}
            };
    
       public static Expression<Func<Employee, bool>> BuildFilterExpression(string datePart, DateTime date, string comparisonOperator)
            {
                var parameter = Expression.Parameter(typeof (Employee), "p");
                Expression member = parameter;
                //the property is a string here, it could be passed as parameter
                //or managed another way
                member = Expression.Property(member, "CreatedDate");
                //let's find the dateDiffMethod
                var dateDiffMethod = typeof (SqlFunctions).GetMethod("DateDiff", new[] {typeof (string), typeof (DateTime), typeof(DateTime)});
                //same for TruncateTime method
                var truncateTimeMethod = typeof (EntityFunctions).GetMethod("TruncateTime", new[] {typeof (DateTime)});
                //first call truncateTime method (to keep only "Date" part)
                var truncateExpression = Expression.Call(truncateTimeMethod, member);
                //call dateDiff method on that
                var dateDiffExpression = Expression.Call(dateDiffMethod, Expression.Constant(datePart), truncateExpression, Expression.Constant(date, typeof(DateTime?)));
                //find the comparison operator
                var comparator = Comparators[comparisonOperator];
                //apply the comparison
                var finalExpression = Expression.MakeBinary(comparator, dateDiffExpression, Expression.Constant(0, typeof(int?)));
                return Expression.Lambda<Func<Employee, bool>>(finalExpression, new []{parameter});
            }
    }
