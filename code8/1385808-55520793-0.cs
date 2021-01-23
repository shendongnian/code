    [TestMethod]
    public void MoviesController_Post_Without_Name()()
    {
        // Arrange
        var model = new MovieModel();
        model.Name = "";
        
        controller.Request = new HttpRequestMessage();
        controller.Configuration = new HttpConfiguration();
        controller.Validate(model);
        
        // Act
        var result = controller.Post(model);
        
        // Assert
        ...
