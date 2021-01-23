        System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("dbserver");
            config.AppSettings.Settings.Remove("dbname");
            config.AppSettings.Settings.Remove("dbuser");
            config.AppSettings.Settings.Remove("dbpass");
            // Add an Application Setting.
            config.AppSettings.Settings.Add("dbserver", txtDBServer.Text);
            config.AppSettings.Settings.Add("dbname", txtDBName.Text);
            config.AppSettings.Settings.Add("dbuser", txtDBUser.Text);
            config.AppSettings.Settings.Add("dbpass", txtDBPassword.Text);
