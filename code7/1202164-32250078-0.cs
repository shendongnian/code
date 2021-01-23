    var xmlDoc = new XmlDocument();
    xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
    xmlDoc.SelectSingleNode("//applicationSettings/MyApp_Application.Properties.Settings/setting/value").InnerText = "server=127.0.0.1;uid=root;pwd=root;database=" + comboBox1.SelectedItem.ToString();
    
    xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
    ConfigurationManager.RefreshSection("applicationSettings/MyApp_Application.Properties.Settings/setting");
