	public class Name 
	{
		private string _firstName;
		private string _lastName;
		public string FirstName
		{
			get { return _firstName; }
			set { _firstName = value; }
		}
		public string LastName 
		{
			get { return _lastName; }
			set { _lastName = value; }
		}
		public string FullName
		{
			get { return _firstName + " " + _lastName; }
		}
	}
