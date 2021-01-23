	[TestMethod]
	public void MyTest()
	{
		MyController controller = new MyController();
			
		ActionResult result = controller.MyAddMethod();
		Assert.IsNotNull(result);
		ViewResult viewResult = result as ViewResult;
		Assert.IsNotNull(viewResult);
		MyDataType myDataObject = viewResult.Model as MyDataType;
		Assert.IsNotNull(myDataObject);
		ValidateViewModel(myController, myDataObject);
		PreBindModel(controller, myDataObject, "MyAddMethod");
		Assert.IsNull(myDataObject.FieldThatShouldBeReset);
		result = controller.MyAddMethod(myDataObject);
		Assert.IsNotNull(result);
		viewResult = result as ViewResult;
		Assert.IsNotNull(viewResult);
		myDataObject = viewResult.Model as MyDataType;
		Assert.IsNotNull(myDataObject.FieldThatShouldBeReset);
	}
