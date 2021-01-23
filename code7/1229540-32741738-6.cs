	var newProducts =  _summaryRepository.GetFilteredSummaries(...)
										 .Where(s => ...)
	var groupedProducts = newProducts.GroupBy(s => 
	{
		if(model.allWidgets)
		{
			return new 
			{
				ProductId = s.ProductId,
				WidgetId = 0,
			};
		}
		else
		{
			return new 
			{
				ProductId = s.ProductId,
				WidgetId = s.WidgetId,
			};
		}
	});
