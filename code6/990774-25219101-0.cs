	var employee = CompanyList.SelectMany(company => company.Subdivisions.SelectMany(division => division.Employees))
					          .FirstOrDefault(emp => emp.EmployeeID == 1);
	if (employee != null)
	{
		Console.WriteLine(employee.EmployeeName); //prints John                  
	}
	else
	{
		Console.WriteLine("Employee with ID 1 not found!");
	}
