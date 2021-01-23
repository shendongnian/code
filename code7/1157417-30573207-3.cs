    [Test]
    public async Task MyTest()
    {
        var expectedMovies = new UpcomingMovies(); // or whatever movies you need
    
        Mock<IApiRequest> mock = new Mock<IApiRequest>();
    mock.Setup(x => x.ExecuteAsync<UpcomingMovies>(It.IsAny<RestRequest>()))
        .Returns(Task.FromResult<UpcomingMovies>(expectedMovies));
    
        var myClass = new MyClass(mock.Object);
        var result = await myClass.GetUpcomingMovies(1);
    
        Assert.IsTrue(expectedMovies == result);    
    }
