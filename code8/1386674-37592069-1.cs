    // Arrange
    const string File = "file.xlsx";
    var xlFactory = new Mock<IExcelDatasourceFactory>();
    var hrbdFactory = new Mock<IDbDatasourceFactory>();
    var k2Factory = new Mock<IK2DatasourceFactory>();
    
    // Act
    var sut = new SunSystemPaymentBroker(xlFactory.Object, hrdbFactory.Object, k2Factory.Object); // I'm assuming you're using constructor injection
    sut.ProcessFile(File);
    
    // Assert
    xlFactory.Verify(m => m.Create(File), Times.Once);
    hrbdFactory.Verify(m => m.Create(), Times.Once);
    k2Factory.Verify(m => m.Create(), Times.Once);
