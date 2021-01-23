    [TestMethod]
    public void Report_PDFExport_Returns_ActionResult()
    {
        //Arrange
        byte[] fakePDFReport = new byte[0];
        var mockRepository = new Mock<IPDFRepository>();
        mockRepository
            .Setup(x => x.BuildExport(It.IsAny<PDFViewModel>()))
            .Returns(fakePDFReport);
        var fakeViewModel = new PDFViewModel {
            //Set the needed properties
        }
    
        ReportController controller = new ReportController(mockRepository.Object);
    
        //Act
        ActionResult result = controller.PDFExport(fakeViewModel);
    
        //Assert
        Assert.IsInstanceOfType(result, typeof(ActionResult));
    }
