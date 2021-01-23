    public class VisitorsViewModel
	{
		public string EmployeeId
		{
			get;
			set;
		}
		public IEnumerable<Employee> Employees
		{
			get;
			set;
		}
	}
    
    //There might be other properties as well in this class
	public class Employee
	{
		public Guid? EmployeeId
		{
			get;
			set;
		}
		public string DisplayName
		{
			get;
			set;
		}
	}
