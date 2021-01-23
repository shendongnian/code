    [Fact, Trait("Category", "Integration")]
    public void ReturnsCorrectAppInstallationFolder()
    {
        // Arrange
        var assemblyFilename = Path.GetFilename(typeof(SomeType).Assembly.Location);
        var provider = new PathProvider();
        
        // Act
        var location = provider.AppInstallationFolder;
    
        // Assert
        Assert.NotEmpty(Directory.GetFiles(location, assemblyFilename))
    }
