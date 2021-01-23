    public class Customer
	{
		public Customer(
			[JsonProperty("Customer.Name")] string name,
			[JsonProperty("Customer.Email")] string email,
			[JsonProperty("Customer.Country")] string country,
			[JsonProperty("Customer.State")] string state,
			[JsonProperty("Customer.City")] string city,
			[JsonProperty("Customer.Phone")] string phone,
			[JsonProperty("Customer.Company")] string company,
			[JsonProperty("Customer.Region")] string region,
			[JsonProperty("Customer.Fax")] string fax,
			[JsonProperty("Customer.Age")] string age,
			[JsonProperty("Customer.Territory")] string territory,
			[JsonProperty("Customer.Occupation")] string occupation
			)
		{
			Name = name;
			Email = email;
			Country = country;
			State = state;
			City = city;
			PhoneNumber = phone;
			Company = company;
			Region = region;
			FaxNumber = FaxNumber;
			Age = age;
			Territory = territory;
			Occupation = occupation;
		}
		public string Name { get; set; }
		public string Email { get; set; }	
		public string Country { get; set; }	
		public string State { get; set; }
		public string City { get; set; }
		public string PhoneNumber { get; set; }
		public string Company { get; set; }
		public string Region { get; set; }
		public string FaxNumber { get; set; }		
		public string Age { get; set; }	
		public string Territory { get; set; }	
		public string Occupation { get; set; }
	}
