        static bool ExecuteOperatorEqual<T>(T item1, T item2)
        {
            BindingFlags bindingAttr = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
            var TType = typeof(T);
            var equalityMethod = TType.GetMethod("op_Equality", bindingAttr, null, new Type[] { typeof(T), typeof(T) }, null);
            while (TType != null && equalityMethod == null)
            {
                equalityMethod = TType.BaseType.GetMethod("op_Equality");
                TType = TType.BaseType;
            }
            var expression = Expression.Lambda<Func<bool>>(
                Expression.Equal(
                    Expression.Constant(item1),
                    Expression.Constant(item2),
                    false,
                    equalityMethod
                    ));
            return expression.Compile()();
        }
