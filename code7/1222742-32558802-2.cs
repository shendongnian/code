    public virtual IList<TEntity> Fill(Expression<Func<TEntity, bool>> filter = null,
            Expression<Func<IQueryable<TEntity>, 
            IOrderedQueryable<TEntity>>> orderBy = null,
            string includeProperties = "") {
            includeProperties = includeProperties ?? "";
            try
            {
                var qctx = new TQueryContext
                {
                    QueryType = filter == null ? CommonQueryType.FillAll : CommonQueryType.FillWhere,
                    FilterNode = filter == null ? null : filter.ToExpressionNode(),
                    OrderByNode = orderBy == null ? null : orderBy.ToExpressionNode()
                };
