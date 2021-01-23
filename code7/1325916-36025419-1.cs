    [TestMethod]
    public void PostMethodSetsLocationHeader()
    {
        // Arrange
        var mockRepository = new Mock<IMovieRepository>();
        var controller = new MoviesAPIController(mockRepository.Object);
        var model = new MovieDTO()
        {
            Title = "Mad Max: Fury Road",
            Released = DateTime.Parse("15 May 2015"),
            GenreIds = new List<int>(){ 1 }
        };
    
        // Act    
        IHttpActionResult actionResult = controller.PostMovies(model);
        var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<MovieDTO>;
    
        // Assert
        Assert.IsNotNull(createdResult);
        Assert.AreEqual("DefaultApi", createdResult.RouteName);
        Assert.AreEqual(model.Title, createdResult.RouteValues["title"]);
    }
