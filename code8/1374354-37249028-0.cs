    static List<EmployeeDepartmentVM> GetEmployeeDepartmentVMList(DbCommand command)
    {
    	var resultById = new Dictionary<int, EmployeeDepartmentVM>();
    	using (var reader = command.ExecuteReader())
    	{
    		var employeeIdCol = reader.GetOrdinal("Id");
    		var employeeNameCol = reader.GetOrdinal("Name");
    		var departmentIdCol = reader.GetOrdinal("DId");
    		var departmentNameCol = reader.GetOrdinal("DName");
    		while (reader.Read())
    		{
    			var departmentId = reader.GetInt32(departmentIdCol);
    			EmployeeDepartmentVM result;
    			if (!resultById.TryGetValue(departmentId, out result))
    			{
    				result = new EmployeeDepartmentVM
    				{
    					department = new Department(),
    					employees = new List<Employee>()
    				};
    				result.department.Id = departmentId;
    				result.department.Name = reader.GetString(departmentNameCol);
    				resultById.Add(departmentId, result);
    			}
    			var employee = new Employee();
    			employee.Id = reader.GetInt32(employeeIdCol);
    			employee.Name = reader.GetString(employeeNameCol);
    			employee.DepartmentId = departmentId;
    			result.employees.Add(employee);
    		}
    	}
    	return resultById.Values.ToList();
    }
