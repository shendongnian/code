    /// <summary>
    /// Tests the Edit method for ActionResult return type
    /// </summary>
    [TestMethod]
    public void StatusViewer_Edit_Returns_ActionResult()
    {
        //Arrange
        var mockRepository = new Mock<IERERepository>();
        mockRepository
            .Setup(m => m.StatusViewerInsert(It.IsAny<StatusViewerFormViewModel>())
            .Verifiable();
    
        var controller = new StatusViewerController(mockRepository.Object);
    
        var model = new StatusViewerFormViewModel {
            RecordID = "set the value of RecordID here",
            ClientNumber = "Other property value here",
            //...other properties
        };
    
        //Act
        ActionResult result = controller.Edit(model);
    
    
        //Assert
        Assert.IsInstanceOfType(result, typeof(ActionResult));
        mockRepository.Verify();//verify that the repository was called.
    }
