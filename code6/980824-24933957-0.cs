	public class Department
	{
		public int DepartmentId {get; set;}
		public string Name {get; set;}
		public List<Employee> Employees {get; set;}
		public Department()
		{
			Employees = new List<Employee>();
		}
	}
	
	public class Employee
	{
		public int EmployeeId {get; set;}
		public string Name {get; set;}
		public Department Department {get; set;}
	}
	
	void Main()
	{
		// set up replica data (much like any ORM would return)  
		List<Department> Departments = new List<Department>();
		List<Employee> iTEmployees = new List<Employee>();
		List<Employee> salesEmployees = new List<Employee>();
		
		Department iT = new Department(){ Name = "IT", DepartmentId = 1 };
		iTEmployees.Add(new Employee(){EmployeeId = 1, Name = "Jo",  Department = iT});
		iTEmployees.Add(new Employee(){EmployeeId = 2, Name = "Jim",  Department = iT });
		iTEmployees.Add(new Employee(){EmployeeId = 3, Name = "James",  Department = iT });
		iT.Employees = iTEmployees;
		Departments.Add(iT);
		
		Department sales = new Department(){ Name = "Sales", DepartmentId = 1 };
		salesEmployees.Add(new Employee(){EmployeeId = 1, Name = "Jo",  Department = sales});
		salesEmployees.Add(new Employee(){EmployeeId = 2, Name = "Jan",  Department = sales });
		salesEmployees.Add(new Employee(){EmployeeId = 3, Name = "Jane",  Department = sales });
		sales.Employees = salesEmployees;
		Departments.Add(sales);
		
		// query objects
		string searchParam = "IT";
		
		List<Employee> employees = /*dataContext.*/Departments.SelectMany(x=>x.Employees.Where(y=>y.Department.Name.ToLowerInvariant() == searchParam.ToLowerInvariant())).ToList();
		employees.Dump();
	}
