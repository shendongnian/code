	public class UserData
	{
		public string UserName;
		public string UserPhone;
	}
	public class CustomerData
	{
		public string CustomerName;
		
		[JsonExtensionData]
		public Dictionary<string, object> Users;
	}
    var data = new CustomerData()
	{
		CustomerName = "Foo",
		Users = new Dictionary<string, object>() 
		{
			{ "1",  new UserData() { UserName = "Fireman", UserPhone = "0118 999 881 999 119 725 ... 3" } },
			{ "2",  new UserData() { UserName = "Jenny", UserPhone = "867-5309" } }
		}
	};
