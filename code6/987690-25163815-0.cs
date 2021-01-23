            Dim config As System.Configuration.Configuration = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None)
            Dim section As System.Configuration.ConnectionStringsSection = DirectCast(config.GetSection("connectionStrings"), System.Configuration.ConnectionStringsSection)
            section.ConnectionStrings(My.Settings.ToString & ".myconnectionstring").ConnectionString = ConnectionString
            section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider")
            config.Save(System.Configuration.ConfigurationSaveMode.Modified)
            System.Configuration.ConfigurationManager.RefreshSection("connectionStrings")
