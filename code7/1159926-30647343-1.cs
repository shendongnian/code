    [TestMethod]
    public void Should_Return_Single_Product()
    {
        // Arrange
        var repo = new FakeRepository<Widget>();
        var controller = new WidgetController(repo);
        var expected = repo.Find(1);
       
       // Act
       var actual = controller.GetWidget(1) as OkNegotiatedContentResult<Widget>;
    
       // Assert
       Assert.IsNotNull(actual);
       Assert.AreEqual(expected.Id, actual.Content.Id);
    }
