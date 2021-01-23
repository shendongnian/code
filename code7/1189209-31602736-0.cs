    var fileMap = new ConfigurationFileMap(Application.StartupPath + @"\GetSettingFilesValues.exe.config");
    var configuration = ConfigurationManager.OpenMappedMachineConfiguration(fileMap);
    var sectionGroup = configuration.GetSectionGroup("applicationSettings"); // This is the section group name, change to your needs, ie application or user
    var section = (ClientSettingsSection)sectionGroup.Sections.Get("GetSettingFilesValues.Properties.s201415"); //This is the section name, change to your needs (you know the tax years you need)
    var setting = section.Settings.Get("LEL");
    System.Diagnostics.Debug.WriteLine(setting.Value.ValueXml.InnerXml);
