     public ExpressionNode FilterNode { get; set; }
     public Expression<Func<TEntity, bool>> Filter 
     { 
        get {
            return FilterNode == null ? null : FilterNode.ToBooleanExpression<TEntity>();
        } 
     }
     public ExpressionNode OrderByNode { get; set; }
    
     public Expression<Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>> OrderBy 
     {
        get {
            return OrderByNode ==  null ? null : OrderByNode.ToExpression<Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>>();
        }
     }
