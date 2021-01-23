        Configuration configManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        KeyValueConfigurationCollection confCollection = configManager.AppSettings.Settings;
        if (confCollection.AllKeys.Contains(ID_UZIVATELE)) {
            Console.Out.WriteLine("Contains key, modifying : was " + confCollection["ID_Uzivatele"].Value);
            confCollection["ID_Uzivatele"].Value = "foo";
        } else {
            Console.Out.WriteLine("Doesn't contain key, adding");
            confCollection.Add(ID_UZIVATELE, "Boom");
        }
        configManager.Save(ConfigurationSaveMode.Modified);
        ConfigurationManager.RefreshSection(configManager.AppSettings.SectionInformation.Name);
