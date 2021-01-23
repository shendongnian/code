	class Employee
	{
		public string FirstName { get; }
		public string LastName { get; }
		public string FullName => $"{FirstName} {LastName}";
	}
	
