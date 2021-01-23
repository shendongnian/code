    [Test]
    public void should_run_GetCommand_with_provided_property_value() {
        // Arrange
        var inputFile = "someInputFile";
        var data = "1,2";
        var expectedCommand = "1,2,abc";
        // Act
        // Note, I'm calling the static method to create your instance
        var sut = Simple.GetNewInstance(inputFile, data);
        // Assert
        Assert.AreEqual(inputFile, sut.InputFile);
        Assert.AreEqual(data, sut.Data);
        Assert.AreEqual(expectedCommand, sut.Command);
    }
