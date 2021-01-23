	class Employee
	{
		public String FirstName { get; }
		public String LastName { get; }
		public String FullName => $"{FirstName} {LastName}";
	}
	
