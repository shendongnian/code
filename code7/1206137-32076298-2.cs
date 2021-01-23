    public static class QExtension
    {
        public static IEnumerable<object> Select<T>(this IQueryable<T> source, 
                                                   Expression<Func<T, object>> exp) where T : class
        {
            var u = exp.Body as UnaryExpression;
            if(u == null) throw new ArgumentException("exp Body should be a UnaryExpression.");            
            //convert the Func<T,object> to Func<T, actualReturnType>
            var funcType = typeof(Func<,>).MakeGenericType(source.ElementType, u.Operand.Type);
            //except the funcType, the new converted lambda expression 
            //is almost the same with the input lambda expression.
            var le = Expression.Lambda(funcType, u.Operand, exp.Parameters);            
            //try getting the Select method of the static class Queryable.
            var sl = Expression.Call(typeof(Queryable), "Select", 
                                     new[] { source.ElementType, u.Operand.Type }, 
                                     Expression.Constant(source), le).Method;
            //finally invoke the Select method and get the result 
            //in which each element type should be the return property type 
            //(returned by selector)
            return ((IEnumerable)sl.Invoke(null, new object[] { source, le })).Cast<object>();
        }        
    }
