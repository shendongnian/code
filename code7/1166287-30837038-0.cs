        #region change configuration file
        /// <summary>
        /// 
        /// </summary>
        /// <param name="createdTime"></param>
        [TestCase("2015-06-12 14:37:59")]
        public void ChangeConfiguration(string createdTime)
        {
            string str = System.Environment.CurrentDirectory+@"\App";  //remove .config  
            string appDomainConfigFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            Configuration config = ConfigurationManager.OpenExeConfiguration(str);          
            AppSettingsSection appSettings = (AppSettingsSection)config.GetSection("appSettings");            
            appSettings.Settings.Remove("queryTime");
            appSettings.Settings.Add("queryTime", createdTime); 
            config.Save();
            ConfigurationManager.RefreshSection("configuration");
        }
        #endregion
