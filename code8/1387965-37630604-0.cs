    public static class MyClass
    {
        public static IQueryable<T> Order<T>(
            IQueryable<T> queryable,
            List<string> fields,
            //We pass LambdaExpression because the selector property type can be anything
            Dictionary<string, LambdaExpression> expressions)
        {
            //Start with input queryable
            IQueryable<T> result = queryable;
            //Loop through fields
            for (int i = 0; i < fields.Count; i++)
            {
                bool ascending = fields[i][0] == '+';
                string field = fields[i].Substring(1);
                LambdaExpression expression = expressions[field];
                MethodInfo method = null;
                
                //Based on sort order and field index, determine which method to invoke
                if (ascending && i == 0)
                    method = OrderbyMethod;
                else if (ascending && i > 0)
                    method = ThenByMethod;
                else if (!ascending && i == 0)
                    method = OrderbyDescendingMethod;
                else
                    method = ThenByDescendingMethod;
                //Invoke appropriate method
                result = InvokeQueryableMethod( method, result, expression);
            }
            return result;
        }
        //This method can invoke OrderBy or the other methods without
        //getting as input the type of the expression return value type
        private static IQueryable<T> InvokeQueryableMethod<T>(
            MethodInfo methodinfo,
            IQueryable<T> queryable,
            LambdaExpression expression)
        {
            var generic_order_by =
                methodinfo.MakeGenericMethod(
                    typeof(T),
                    expression.ReturnType);
            return (IQueryable<T>)generic_order_by.Invoke(
                null,
                new object[] { queryable, expression });
        }
        private static readonly MethodInfo OrderbyMethod;
        private static readonly MethodInfo OrderbyDescendingMethod;
        private static readonly MethodInfo ThenByMethod;
        private static readonly MethodInfo ThenByDescendingMethod;
        //Here we use reflection to get references to the open generic methods for
        //the 4 Queryable methods that we need
        static MyClass()
        {
            OrderbyMethod = typeof(Queryable)
                .GetMethods()
                .First(x => x.Name == "OrderBy" &&
                            x.GetParameters()
                                .Select(y => y.ParameterType.GetGenericTypeDefinition())
                                .SequenceEqual(new[] { typeof(IQueryable<>), typeof(Expression<>) }));
            OrderbyDescendingMethod = typeof(Queryable)
                .GetMethods()
                .First(x => x.Name == "OrderByDescending" &&
                            x.GetParameters()
                                .Select(y => y.ParameterType.GetGenericTypeDefinition())
                                .SequenceEqual(new[] { typeof(IQueryable<>), typeof(Expression<>) }));
            ThenByMethod = typeof(Queryable)
                .GetMethods()
                .First(x => x.Name == "ThenBy" &&
                            x.GetParameters()
                                .Select(y => y.ParameterType.GetGenericTypeDefinition())
                                .SequenceEqual(new[] { typeof(IOrderedQueryable<>), typeof(Expression<>) }));
            ThenByDescendingMethod = typeof(Queryable)
                .GetMethods()
                .First(x => x.Name == "ThenByDescending" &&
                            x.GetParameters()
                                .Select(y => y.ParameterType.GetGenericTypeDefinition())
                                .SequenceEqual(new[] { typeof(IOrderedQueryable<>), typeof(Expression<>) }));
        }
    }
