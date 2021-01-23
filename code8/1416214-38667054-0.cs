    internal static IProjection ProcessCoalesce(MethodCallExpression methodCallExpression)
    {
      IProjection projection = ExpressionProcessor.FindMemberProjection(methodCallExpression.Arguments[0]).AsProjection();
      object obj = ExpressionProcessor.FindValue(methodCallExpression.Arguments[1]);
      return Projections.SqlFunction("coalesce", (IType) NHibernateUtil.Object, projection, Projections.Constant(obj));
    }
