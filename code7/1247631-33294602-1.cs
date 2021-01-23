    public void CacheInitialize()
    {
        string lastLogin = ConfigurationManager.AppSettings["LastLogin"];
        if (String.IsNullOrEmpty(lastLogin)) return;        
        int userId;
        if (!int.TryParse(lastLogin, out userId)) 
            throw new ArgumentException("LastLogin is not an integer.");
        SelectedUser = Users.First(x => x.Id == userId);
    }
    public void CacheSave()
    {
    	Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        if (configuration.AppSettings.Settings["LastLogin"] == null)
            configuration.AppSettings.Settings.Add("LastLogin", SelectedUser.Id.ToString());
        else
            configuration.AppSettings.Settings["LastLogin"].Value = SelectedUser.Id.ToString();
	    configuration.Save();
    	ConfigurationManager.RefreshSection("appSettings");
    }
