	public async Task<int> PullAsync<TModel, TFilter>() 
						   where TModel : IModel, 
						   where TFilter : IFilter, new();
	{
		var service = new DesktopConnectorService<TModel>(
						new WapiRepository<TModel>(), new QuickBooksRepository<TModel>());
		var filter = new TFilter();
		try
		{
			var items = await service.GetItemsAsync(filter);
			return items.Count;
		}
		catch (Exception ex)
		{
		}
		return 0;
	}
	
