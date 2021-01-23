    Configuration objConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            AppSettingsSection objAppsettings = (AppSettingsSection)objConfig.GetSection("appSettings");
           
            if (objAppsettings != null)
            {
                objAppsettings.Settings.Add("hello", "world");
                objConfig.Save();
            }
