    public void should_run_GetCommand_with_provided_property_value() {
        // Arrange
        var fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
        // create and inject an instances of the IFileWrapper class so that we 
        // can setup expectations
        var fileWrapperMock = fixture.Freeze<IFileWrapper>();
        // Setup expectations on the Substitute.  Note, this isn't needed for
        // this test, since the sut doesn't actually use inputFile, but I've
        // included it to show how it works...
        fileWrapperMock.File.Returns(new FileInfo(@"c:\pagefile.sys"));
        // This is effectively Act, since everything happens in the constructor
        // Create the sut.  fileWrapperMock will be injected as the inputFile
        // since it is an interface, a random string will go into data
        var sut = fixture.Create<Simple>();
        // Assert - Check that sut.Command has been updated as expected
        Assert.AreEqual(sut.Data + ",abc", sut.Command);
        // You could also test the substitute is don't what you're expecting
        Assert.AreEqual("pagefile.sys", sut.InputFile.File.Name);
    }
