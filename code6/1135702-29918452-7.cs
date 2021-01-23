    class Mapper<TSource, TTarget> : Mapper
    {
        public Mapper()
            : base(typeof(TSource).FullName, typeof(TTarget).FullName)
        {
    
        }
    
        private static string GetExpressionMemberAccess(LambdaExpression getProperty)
        {
            var member = (MemberExpression)getProperty.Body;
            //var lambdaParameterName = (ParameterExpression)member.Expression;
            var lambdaParameterName = getProperty.Parameters[0]; // `x` in `x => x.PropertyName`
            var labmdaBody = member.ToString();
            //will not work with indexer.
            return labmdaBody.Substring(lambdaParameterName.Name.Length + 1); //+1 to remove the `.`, get "PropertyName"
        }
    
        public void Add<TProperty>(Expression<Func<TSource, TProperty>> getSourceProperty, Expression<Func<TTarget, TProperty>> getTargetProperty)
        {
            Add(GetExpressionMemberAccess(getSourceProperty), GetExpressionMemberAccess(getTargetProperty));
        }
    
        /// <summary>
        /// The doesn't really make sense, but we assume we have <c>source=>source.Property</c>, <c>target=>target.Property</c>
        /// </summary>
        public void Add<TProperty>(Expression<Func<TSource, TProperty>> getProperty)
        {
            Add(GetExpressionMemberAccess(getProperty));
        }
    }
