    internal void WriteSettings(string sectionName, bool isRoaming, IDictionary newSettings)
    {
    	if (!ConfigurationManagerInternalFactory.Instance.SupportsUserConfig)
    	     throw new ConfigurationErrorsException(System.SR.GetString("UserSettingsNotSupported"));
    	...
    	if (configSection == null)
    	     throw new ConfigurationErrorsException(System.SR.GetString("SettingsSaveFailedNoSection"));
        ...
    	try
    	{
    	    userConfig.Save();
    	}
    	catch (ConfigurationErrorsException ex)
    	{
    	     throw new ConfigurationErrorsException(System.SR.GetString("SettingsSaveFailed", new object[1]
    	          {
    		       (object) ex.Message
    	          }), (Exception) ex);
    	}
    }
