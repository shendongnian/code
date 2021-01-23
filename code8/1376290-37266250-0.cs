    try
    {
        var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
        //Check user.config exists
        if (!File.Exists(config.FilePath))
        {
            DropLib.Properties.Settings.Default.Save();
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
        }
    
        // returns "[MyApplication].Properties.Settings";
        string appSettingsXmlName = Properties.Settings.Default.Context["GroupName"].ToString();
    
        // Open settings file as XML
        var import = XDocument.Load(filename);
                        
        // Get the whole XML inside the settings node
        var settings = import.XPathSelectElements("//" + appSettingsXmlName);
                        
        config.GetSectionGroup("userSettings")
            .Sections[appSettingsXmlName]
            .SectionInformation
            .SetRawXml(settings.Single().ToString());
                        
        config.Save(ConfigurationSaveMode.Modified);
        ConfigurationManager.RefreshSection("userSettings");
    
        appSettings.Reload();
    }
    catch (Exception ex)
    {
        MessageBox.Show("Could not import settings. " + ex.Message);
        appSettings.Reload(); // from last set saved, not defaults
    }
