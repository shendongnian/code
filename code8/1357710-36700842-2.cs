	public virtual async Task<IActionResult> Index()
	{
		// dynamic include:
		// dbset is for instance ctx.ArticleContents
		var queryable = includeIndexExpressionList
			.Aggregate(dbSet.AsQueryable(), (current, include) => current.Include(include));
		if(IndexAdditionalQuery != null) queryable = IndexAdditionalQuery(queryable);
		var list = await queryable.Take(100).AsNoTracking().ToListAsync();
		var viewModelList = list.Map<IList<TModel>, IList<TViewModel>>();
		return View(viewModelList);
	}
