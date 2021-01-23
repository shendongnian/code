    public int Main()
    {
        Expression<Func<MyClass, bool>> whereClause =
            BuildOrExpressionTree<MyClass, int>(list, m => m.Foo + m.Bar);
        var myClasss = model.Set<MyClass>();
        IQueryable<MyClass> query = myClasss.Where(whereClause);
    }
    /// <summary>
    /// Starts a recursion to build WHERE (m.Foo = X1 AND m.Bar = Y1) [OR (m.Foo = X2 AND m.Bar = Y2) [...]].
    /// </summary>
    private static Expression<Func<TValue, bool>> BuildOrExpressionTree<TValue, TCompareAgainst>(
        IEnumerable<FooBarPair> wantedItems,
        Expression<Func<TValue, TCompareAgainst>> convertBetweenTypes1)
    {
        ParameterExpression inputParam1 = convertBetweenTypes1.Parameters[0];
        BinaryExpression binaryExpression = convertBetweenTypes1.Body as BinaryExpression;
        Expression binaryExpressionTree = BuildBinaryOrTree<FooBarPair>(
            wantedItems.GetEnumerator(),
            binaryExpression.Left,
            binaryExpression.Right,
            null);
        return Expression.Lambda<Func<TValue, bool>>(binaryExpressionTree, new[] { inputParam1 });
    }
    /// <summary>
    /// Recursive function to append one 'OR (m.Foo == X AND m.Bar == Y)' expression.
    /// </summary>
    private static Expression BuildBinaryOrTree<T>(
        IEnumerator<FooBarPair> itemEnumerator,
        Expression expressionToCompareTo1,
        Expression expressionToCompareTo2,
        Expression prevExpression)
    {
        if (itemEnumerator.MoveNext() == false)
        {
            return prevExpression;
        }
        ConstantExpression fooConstant = Expression.Constant(itemEnumerator.Current.Foo, typeof(int));
        ConstantExpression barConstant = Expression.Constant(itemEnumerator.Current.Bar, typeof(int));
        BinaryExpression fooComparison = Expression.Equal(expressionToCompareTo1, fooConstant);
        BinaryExpression barComparison = Expression.Equal(expressionToCompareTo2, barConstant);
        BinaryExpression newExpression = Expression.AndAlso(fooComparison, barComparison);
        if (prevExpression != null)
        {
            newExpression = Expression.OrElse(prevExpression, newExpression);
        }
        return BuildBinaryOrTree<FooBarPair>(
            itemEnumerator,
            expressionToCompareTo1,
            expressionToCompareTo2,
            newExpression);
    }
