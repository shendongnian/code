    public void CacheInitialize()
    {
        string lastLogin = ConfigurationManager.AppSettings["LastLogin"];
        if (String.IsNullOrEmpty(lastLogin)) return;        
        int userId;
        if (!int.TryParse(lastLogin, out userId)) 
            throw new ArgumentException("LastLogin is not a integer.");
        SelectedUser = Users.First(x => x.Id == int.Parse());
    }
    public void CacheSave()
    {
    	Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    	configuration.AppSettings.Settings["LastLogin"].Value = SelectedUser.Id.ToString();
	    configuration.Save();
    	ConfigurationManager.RefreshSection("appSettings");
    }
