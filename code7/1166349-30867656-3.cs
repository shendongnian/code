    public interface ISettingsService
    	{
    		int DatabaseVersion { get; set; }
    		[...]
    	}
    
        public class SettingsService : ISettingsService
    	{
            private string databaseVersionKey = "DatabaseVersion";
    		public int DatabaseVersion
    		{
    			get { return CrossSettings.Current.GetValueOrDefault(databaseVersionKey, 0); } 
    			set
    			{
    				CrossSettings.Current.AddOrUpdateValue(databaseVersionKey, value);
    			}
    		}
    }
