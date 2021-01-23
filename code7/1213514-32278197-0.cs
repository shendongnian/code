    class Employee
    {
        private int _employeeID;
		
		public int EmployeeId
		{
			get
			{
				Console.WriteLine("The Employee.EmployeeId get operation was called.");
				return _employeeID;
			}
			set
			{
				Console.WriteLine("The Employee.EmployeeId set operation was called.");
				_employeeID = value;
			}
		}
	}
	
	class Program
	{
		public static void Main()
		{
			var e = new Employee();
			
			e.EmployeeId++; // or any other exaple.
		}
	}
