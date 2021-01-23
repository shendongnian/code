    public class ConsoleSection : ConfigurationSection
	{
		[ConfigurationProperty("Username", IsRequired = true)]
		public string Username
		{
			get
			{
				return (string)this["Username"];
			}
			set
			{
				this["Username"] = value;
			}
		}
		[ConfigurationProperty("Password", IsRequired = true)]
		public String Password
		{
			get
			{
				return (String)this["Password"];
			}
			set
			{
				this["Password"] = value;
			}
		}
		[ConfigurationProperty("LanAddress", IsRequired = true)]
		public string LanAddress
		{
			get
			{
				return (string)this["LanAddress"];
			}
			set
			{
				this["LanAddress"] = value;
			}
		}
		[ConfigurationProperty("Port", IsRequired = false)]
		[IntegerValidator(ExcludeRange = false, MaxValue = short.MaxValue, MinValue = short.MinValue)]
		public int Port
		{
			get
			{
				return (int)this["Port"];
			}
			set
			{
				this["Port"] = value;
			}
		}
	}
