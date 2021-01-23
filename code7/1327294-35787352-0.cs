	namespace TestConsole
	{
		class Customer
		{
			public int DeviceID;
			public int Longitude;
			public int Latitude;
			public string Device;
		}
		class Program
		{
			private static Dictionary<string, Customer> ReadXmlToDictionary(string filename)
			{
				var dict = new Dictionary<string, Customer>();
				var doc = XDocument.Load(@"C:\Users\tstandish.TPS\Desktop\test.xml");
				dict = doc.Descendants("cust")
					.ToDictionary(
						row => (string)row.Attribute("Name"),
						row => new Customer {
							Device = (string)row.Attribute("Device"),
							DeviceID = (int)row.Attribute("DeviceID"),
							Latitude = (int)row.Attribute("Latitude"),
							Longitude = (int)row.Attribute("Longitude")
					});
				return dict;
			}
			static void Main(string[] args)
			{
				ReadXmlToDictionary(null);
			}
		}
	}
