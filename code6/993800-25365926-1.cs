    [Test]
    public void ShouldProvideFullProductionServiceConnectionRecord()
    {
        //NOTE: Open ConfigTests.config in this project to see available ServiceConnection records
    
        //Arrange
        ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap { ExeConfigFilename = "ConfigTests.config" };
        Configuration config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                
        ServiceConnectionSection section = config.GetSection("AutomationPressDataCollectionServiceConnections") as ServiceConnectionSection;
    
        //Act
        var productionSection = section.Connections.Get("0Q8");
    
        //Assert
        Assert.AreEqual("0AB0", productionSection.LocationNumber);
        Assert.AreEqual("DEVSERVER", productionSection.HostName);
        Assert.AreEqual(1234, productionSection.Port);
        Assert.AreEqual("DEVELOPMENT", productionSection.Environment);
    }
