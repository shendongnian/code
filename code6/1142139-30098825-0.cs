    void Main()
	{
		UserPreferences preference = new UserPreferences
		{
			BackgroundColor = "#fff",
			ForegroundColor = "#000",
			Language = "en-GB",
			UtcOffSetTimeZone = 0
		};
		
		User aydin = new User(preference);
	}
	
	public class User
	{
		public User(UserPreferences preferences)
		{
			this.Preferences = preferences;
		}
		
		public UserPreferences Preferences { get; set; }
	}
	
	public class UserPreferences
	{
		public string BackgroundColor { get; set; }
		public string ForegroundColor { get; set; }
		public int UtcOffSetTimeZone { get; set; }
		public string Language { get; set; }
	}
