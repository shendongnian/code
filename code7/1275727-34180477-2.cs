	private Lazy<Task<IDictionary<string, IBusinessObject>>> _lazyTask =
		new Lazy<Task<IDictionary<string, IBusinessObject>>>(FetchBusinessObjects);
		
	private static async Task<IDictionary<string, IBusinessObject>> FetchBusinessObjects()
	{
		var businessObjectService = ServiceLocator.Current.GetInstance<IBusinessObjectService>();
		return await businessObjectService.GetData(CancellationToken.None).ToDictionary(e => e.ItemId);
	}
	public async Task GetData(IList<TBusinessItem> items)
	{
		Log.Info("Starting GetData()");
		
		var businessObjects = await _lazyTask.Value;
		items.ToList().ForEach
		(
			item =>
			{
				IBusinessObject businessObject;
				businessObjects.TryGetValue(item.Id, out businessObject);
				item.BusinessObject = businessObject;
			}
		);
	}
