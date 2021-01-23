	var newProducts =  _summaryRepository.GetFilteredSummaries(...)
										 .Where(s => ...)
	IGrouping<something> groupedProducts;
	
	if(model.allWidgets)
	{
		groupedProducts = newProducts.GroupBy(s => new {ProductId = s.ProductId });
	}
	else
	{
		groupedProducts = newProducts.GroupBy(s => new { WidgetId = s.WidgetId, ProductId = s.ProductId });
	}
