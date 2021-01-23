	public class Employee
	{
		public int ID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Gender { get; set; }
	}
	
	public class ContractEmployee
	{
		public int ID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Gender { get; set; }
		public int HoursWorked { get; set; }
		public int HourlyPay { get; set; }
	}
	
	public class PermanentEmployee
	{
		public int ID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Gender { get; set; }
		public int AnnualSalary { get; set; }
	}
