	public async Task<IHttpActionResult> MethodB()
	{
		var customer = new Customer();
		var getAllWidgetsTask = _widgetService.GetAllWidgets();
		var getAllFoosTask = _fooService.GetAllFos();
		await Task.WhenAll(getAllWidgetsTask, getAllFoosTask);
		customer.Widgets = await getAllWidgetsTask;
		customer.Foos = await getAllFoosTask;
		return Ok(customer);
	}
