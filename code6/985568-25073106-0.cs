    var visited = new HashSet<Employee>();
	var stack = new Stack<Employee>(); // DFS
	stack.Push(ceo);
	while (stack.Count != 0)
	{
		var current = stack.Pop();
		IList<Employee> employeeList = current.getReports();
		foreach (var employee in employeeList)
		{
			employee.Bosses.AddRange(current.Bosses);
			employee.Bosses.Add(current);
			employee.DistanceFromCeo = current.DistanceFromCeo + 1;
			if (firstEmployee.getId() == employee.getId())
			{
				firstEmployee.Bosses.AddRange(employee.Bosses);
			}
			if (secondEmployee.getId() == employee.getId())
			{
				secondEmployee.Bosses.AddRange(employee.Bosses);
			}
			if (visited.Add(employee))
			{
				stack.Push(employee);
			}
		}
	}
