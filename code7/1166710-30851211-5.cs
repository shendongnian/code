	public class Employee
	{
		public string FirstNameP { get; set; }
		public string LastNameP { get; set; }
		public int AgeP { get; set; }
		public string DepartmentP { get; set; }
		public string AddressP{ get; set; }
	}
	[XmlRoot("Employees")]
	public class MyWrapper
	{
		private List<Employee> items = new List<Employee> ();
		public List<Employee> Items { 
			get { return items; } 
			set { items = value;}
		}
	}
