    public void Team_Index_should_return_valid_model()
    {
    	using (var context = new TheContext(CreateNewContextOptions()))
    	{
    		//Arrange
    		CreateTestData(context);
    		var controller = new TeamController(context);
    
    		//Act
    		var actionResult = controller.Index();
    
    		//Assert
    		Assert.NotNull(actionResult);
    		Assert.True(actionResult.Result is ViewResult);
    		var model = ModelFromActionResult<List<Team>>((ActionResult)actionResult.Result);
    		Assert.Equal(20, model.Count);
    	}
    }
