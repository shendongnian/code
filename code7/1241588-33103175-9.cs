	class Employee
	{
		public Employee(string firstName, string lastName)
		{
			FirstName = firstName;
			LastName = lastName;
			fullName = $"{FirstName} {LastName}";
		}
		
		public string FirstName { get; }
		public string LastName { get; }
		private string fullName;
	}
