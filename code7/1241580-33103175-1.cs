	class Employee
	{
		public Employee(string firstName, string lastName)
		{
			FirstName = firstName;
			LastName = lastName;
			fullName = $"{FirstName} {LastName}";
		}
		
		public String FirstName { get; }
		public String LastName { get; }
		private String fullName;
	}
