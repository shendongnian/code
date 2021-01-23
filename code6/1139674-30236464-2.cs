    var map = new ExeConfigurationFileMap();
    map.MachineConfigFilename = PathToCustomConfig;
    map.ExeConfigFilename = PathToAppConfig;
                    
    var configuration = ConfigurationManager.OpenMappedExeConfiguration(
            map, 
            ConfigurationUserLevel.None);
    var section = configuration.GetSection("custom") as CustomConfigSection;
    Assert.IsNotNull(section);
    
    Assert.AreEqual(section.SingleProperty.Value, "OverriddenValue");
    Assert.AreEqual(section.PropertyCollection.Count, 4);
    // Needed to map the properties as dictionary, not to rely on the property order
    var values = section.PropertyCollection
            .Cast<SimpleConfigElement>()
            .ToDictionary(x => x.ID, x => x.Value);
    Assert.AreEqual(values["1"], "OverridenOne");
    Assert.AreEqual(values["2"], "Two");
    Assert.AreEqual(values["3"], "Three");
    Assert.AreEqual(values["4"], "Four");
