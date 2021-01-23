    public void GetLEL()
    {
        var fileMap = new ConfigurationFileMap(AppDomain.CurrentDomain.BaseDirectory + @"CustomAddIn.dll.config");
        var configuration = ConfigurationManager.OpenMappedMachineConfiguration(fileMap);
        var sectionGroup = configuration.GetSectionGroup("userSettings");
        var section = (ClientSettingsSection)sectionGroup.Sections.Get("MyAddIn.s201213");
        var setting = section.Settings.Get("LEL");
        System.Diagnostics.Debug.WriteLine(setting.Value.ValueXml.InnerXml);
        // Prints "107" as expected.
    }
