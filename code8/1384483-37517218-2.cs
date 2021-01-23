        static bool ExecuteOperatorEqual<T>(T item1, T item2)
        {
            var TType = typeof(T);
            var equalityMethod = TType.GetMethod("op_Equality");
            while (TType != null && equalityMethod == null)
            {
                equalityMethod = TType.BaseType.GetMethod("op_Equality");
                TType = TType.BaseType;
            }
            var equal = typeof(B).GetMethod("op_Equality");
            var expression = Expression.Lambda<Func<bool>>(
                Expression.Equal(
                    Expression.Constant(item1),
                    Expression.Constant(item2), 
                    false,
                    equalityMethod
                    ));
            return expression.Compile()();
        }
