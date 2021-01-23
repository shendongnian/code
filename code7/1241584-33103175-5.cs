	class Employee
	{
		public string FirstName { get; }
		public string LastName { get; }
		public string FullName 
		{
			get { return string.Format("{0} {1}", FirstName, LastName); } 
		}
	}
	
