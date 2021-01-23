    	public class Customer
		{
			public string Name;
			public string Address;
			public string City;
			public string Gender;
			public DateTime Birthdate;
			public int NumberOfKids;
		}
		public IEnumerable<Customer> CustomerSearch(
			string partialName = null,
			string partialAddress = null,
			string partialCity = null,
			string gender = null,
			DateTime? exactBirthdate = null,
			DateTime? startDate = null,
			DateTime? endDate = null,
			int? minNumberOfKids = null)
		{
			// Sample data
			var customers = new [] {
				new Customer { Name = "Jack", Birthdate = DateTime.Today.AddYears(-30), NumberOfKids = 1 },
				new Customer { Name = "Jill", Birthdate = DateTime.Today.AddYears(-33).AddMonths(3), NumberOfKids = 2 },
				new Customer { Name = "Bob", Birthdate = DateTime.Today.AddYears(-35), NumberOfKids = 3 }
			};
			var query =
				from c in customers
				where (String.IsNullOrWhiteSpace(partialName) || c.Name.Contains(partialName))
				   && (String.IsNullOrWhiteSpace(partialAddress) || c.Address.Contains(partialAddress))
				   && (String.IsNullOrWhiteSpace(partialCity) || c.City.Contains(partialCity))
				   && (String.IsNullOrWhiteSpace(gender) || c.Gender == gender)
				   && (!exactBirthdate.HasValue || c.Birthdate.Date == exactBirthdate.Value.Date)
				   && (!startDate.HasValue || !endDate.HasValue || c.Birthdate.Date >= startDate.Value.Date && c.Birthdate.Date <= endDate.Value.Date)
				   && (!minNumberOfKids.HasValue || c.NumberOfKids >= minNumberOfKids.Value)
				select c;
			return query;
		}
