    static IEnumerable<EmployeeDepartmentVM> GetEmployeeDepartmentVMs(DbCommand command)
    {
    	using (var reader = command.ExecuteReader())
    	{
    		var employeeIdCol = reader.GetOrdinal("Id");
    		var employeeNameCol = reader.GetOrdinal("Name");
    		var departmentIdCol = reader.GetOrdinal("DId");
    		var departmentNameCol = reader.GetOrdinal("DName");
    		for (bool more = reader.Read(); more;)
    		{
    			var result = new EmployeeDepartmentVM
    			{
    				department = new Department(),
    				employees = new List<Employee>()
    			};
    			result.department.Id = reader.GetInt32(departmentIdCol);
    			result.department.Name = reader.GetString(departmentNameCol);
    			do
    			{
    				if (reader.IsDBNull(employeeIdCol)) continue;
    				var employee = new Employee();
    				employee.Id = reader.GetInt32(employeeIdCol);
    				employee.Name = reader.GetString(employeeNameCol);
    				employee.DepartmentId = result.department.Id;
    				result.employees.Add(employee);
    			}
    			while ((more = reader.Read()) && reader.GetInt32(departmentIdCol) == result.department.Id);
    			Debug.Assert(!more || reader.GetInt32(departmentIdCol) > result.department.Id); // Sanity check
    			yield return result;
    		}
    	}
    }
