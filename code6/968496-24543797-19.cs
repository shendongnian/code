    class QueryResultItem<T>
    {
        public T Entity { get; set; }
        public IEnumerable<AuditLog> Logs { get; set; }
    }
    class ExpressionSubstitute : ExpressionVisitor
    {
        private readonly Expression _from;
        private readonly Expression _to;
        public ExpressionSubstitute(Expression from, Expression to)
        {
            _from = from;
            _to = to;
        }
        public override Expression Visit(Expression node)
        {
            return node == _from ? _to : base.Visit(node);
        }
    }
    static Expression<Func<AuditLog, bool>> SubstituteSecondParameter<T>(Expression<Func<AuditLog, T, bool>> expression, ParameterExpression parameter)
    {
        ExpressionSubstitute swapParam = new ExpressionSubstitute(expression.Parameters[1], parameter);
        return Expression.Lambda<Func<AuditLog, bool>>(swapParam.Visit(expression.Body), expression.Parameters[0]);            
    }
    static IQueryable<QueryResultItem<T>> GetEntities2<T>(IDbSet<T> entitySet, IDbSet<AuditLog> auditLogSet, Expression<Func<AuditLog, T, bool>> whereTemplate) where T : class
    {
        Expression<Func<AuditLog, bool>> whereExpression = null;                        
        Expression<Func<T, QueryResultItem<T>>> entityExpression = entity =>
            new QueryResultItem<T>
            {
                Entity = entity,
                Logs = auditLogSet.Where(whereExpression)
            };
        whereExpression = SubstituteSecondParameter(whereTemplate, entityExpression.Parameters[0]);
        return entitySet.Select(entityExpression);
    }
