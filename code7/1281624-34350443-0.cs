    /// <summary>
    /// Build an ICriterion for the given property
    /// </summary>
    /// <param name="expression">lambda expression identifying property</param>
    /// <returns>returns LambdaRestrictionBuilder</returns>
    public static LambdaRestrictionBuilder On<T>(Expression<Func<T, object>> expression)
    {
        ExpressionProcessor.ProjectionInfo projection = ExpressionProcessor.FindMemberProjection(expression.Body);
        return new LambdaRestrictionBuilder(projection);
    }
