	public class ConfigurationValuesViewModel
	{
		public List<KeyValuePair<string, string>> AppSettingsValues { get; private set; }
		
		public ConfigurationValuesViewModel()
		{
			AppSettingsValues = new List<KeyValuePair<string, string>>();
		}
	}
	
