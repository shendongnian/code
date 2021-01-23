        static bool ExecuteOperatorEqual<T>(T item1, T item2)
        {
            BindingFlags bindingAttr = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
            var equalityMethod = typeof(T).GetMethod("op_Equality", bindingAttr, null, new Type[] { typeof(T), typeof(T) }, null);
            var expression = Expression.Lambda<Func<bool>>(
                Expression.Equal(
                    Expression.Constant(item1),
                    Expression.Constant(item2),
                    false,
                    equalityMethod
                    ));
            return expression.Compile()();
        }
