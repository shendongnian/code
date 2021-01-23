        static bool ExecuteOperatorEqual<T>(T item1, T item2)
        {           
            var expression = Expression.Lambda<Func<bool>>(
                Expression.Equal(
                    Expression.Constant(item1),
                    Expression.Constant(item2), 
                    false, 
                    typeof(A).GetMethod("op_Equality")
                    ));
            return expression.Compile()();
        }
