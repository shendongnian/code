    [TestMethod]
    public void TestSomething()
    {
        //Arrange
        var mockRepository1 = new Mock<IEditDataRepository>();
    
        mockRepository1
           .Setup(x => x.Edit(It.IsAny<FormViewModel>()));
        HomeController controller = new HomeController(mockRepository1.Object);
        controller.ModelState.AddModelError("error", "invalid model");
    
        //Act/Assert
        var ex = Assert.Throws<HttpException>(() => controller.Edit(It.IsAny<UTCFormViewModel>()));
    
        Assert.Equal(400, ex.ErrorCode);
    }
