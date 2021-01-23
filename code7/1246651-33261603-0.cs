	[HttpPost]
	public JsonResult GetJson(DataTablesParam param)
	{
		using (var context = new SalesContext())
		{
			return context.Sales
				.TrustedSortToPagedList(param.ToPagingCriteria())
				.Select(s => new SaleViewModel(s))
				.ToDataTableResult(param.Draw);
		}
	}
