    ViewModel viewModel= new ViewModel
	{               
	    Departments = response.Departments.Select(x => 
        { 
			x.Employees = x.Employees.Take(50).ToList(); 
			return x;
		})
        .ToList()
	};
