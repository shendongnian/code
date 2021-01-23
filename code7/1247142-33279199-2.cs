	public class Employee
	{
		// Other properties
		
		[NotMapped]
		public string ClientAddress
		{
			get
			{
				return "Client address: " + Address;
			}
		}
	}
