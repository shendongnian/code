	public ActionResult GetConfigurationValues()
	{
		// Fill the ViewModel with all AppSettings Key-Value pairs
		var model = new ConfigurationValuesViewModel();		
		foreach (string key in ConfigurationManager.AppSettings.AllKeys)
		{
			string value = ConfigurationManager.AppSettings[key];
			model.AppSettingsValues.Add(new KeyValuePair<string, string>(key, value);
		}
		
		return View(model);
	}
	
