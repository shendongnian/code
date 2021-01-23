	[TestMethod]
	public void Test_Index()
	{
		//Arrange
		ProductsController prodController = new ProductsController(); // you should mock your DbContext and pass that in
		
		// Act
		var result = prodController.Index() as ViewResult;
		
		// Assert
		Assert.IsNotNull(result);
		Assert.IsNotNull(result.Model); // other checks on Model
		Assert.IsTrue(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Index");
	}
