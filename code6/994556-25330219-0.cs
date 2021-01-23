    class Program
	{
		static void Main(string[] args)
		{
			List<ICompany> AllCompanies  = new List<ICompany>();
			AllCompanies.Add(new Company());
			AllCompanies.Add(new SmallCompany());
			AllCompanies.Add(new LargeCompany());
			List<Employee> AllEmployees = new List<Employee>();
			foreach(var Company in AllCompanies)
			{ 
				Company.Employees.ForEach((Employee)=>
				{
					if(Employee.IsActive)
						AllEmployees.Add(Employee);
				});
			}
		}
	}
	class Employee
	{
		public string Name;
		public int Age;
		public bool IsActive;
		public Employee(string name, int age)
		{
			Name = name;
			Age = age;
		}
	}
	interface ICompany
	{
		List<Employee> Employees { get; set; }
	}
	class Company: ICompany
	{
		public List<Employee> Employees { get; set; }
	}
	class SmallCompany : ICompany
	{
		public List<Employee> Employees { get; set; }
	}
	class LargeCompany : ICompany
	{
		public List<Employee> Employees { get; set; }
	}
