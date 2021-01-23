    // Arrange
    var mockFileSystem = new Mock<IFileSystem>();
    var sut = new Mock<SourceFileBase>(mockFileSystem.Object);
    sut.RemoveAfterTransfer = true;
    sut.Uri = myTestUri;
    // Act
    sut.Dispose();
    // Assert
    mockFileSystem.Verify(f => f.DeleteFile(myTestUri.AbsolutePath));
