    // your existing method
	[ServiceControllerResult(typeof(MyControllerResult))]
	public ActionResult MyMethod(MyControllerRequest request)
	{
		var response = new ServiceResponse<MyControllerResult>();
		// added call
		var fullTypeOfResult = this.GetType().GetServiceControllerDecoratedType(nameof(MyMethod));
		// do something
		return ServiceResult(response);
	}
