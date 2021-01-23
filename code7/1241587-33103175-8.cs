	class Employee
	{
		public string FirstName { get; private set; }
		public string LastName { get; private set; }
		public string FullName 
		{
			get { return string.Format("{0} {1}", FirstName, LastName); } 
		}
	}
	
