    var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    var secGroup = config.SectionGroups["userSettings"]; // or applicationSettings
    
    if (secGroup != null)
    {
    	var clientSettings = (ClientSettingsSection)secGroup.Sections[0];
    
    	var settingElementCollection = clientSettings.Settings;
    
    	var setting = settingElementCollection.Get(Name);
    
    	var value = setting.Value.ValueXml.InnerText;
    }
