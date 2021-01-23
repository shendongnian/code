	private Func<IQueryable<TModel>, IQueryable<TModel>>  IndexAdditionalQuery { get; set; }
	protected void SetAdditionalQuery(Func<IQueryable<TModel>, IQueryable<TModel>> queryable)
	{
		IndexAdditionalQuery = queryable;
	}
