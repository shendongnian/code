    Dictionary<string, ObservableCollection<Employee>> EmpList = DepList.Select(m => new
    {
    	Dep = m.DepName,
    	EmpCollection = 
    	m.sortEmpName == SortDirection.Ascending ? 
    		new ObservableCollection<Employee>(m.EmpName.Select(k => new Employee {EmpName = k, IsChecked = true}).ToList().OrderBy(emp => emp.EmpName)) :
    	m.sortEmpName == SortDirection.Descending ?
    		new ObservableCollection<Employee>(m.EmpName.Select(k => new Employee { EmpName = k, IsChecked = true }).ToList().OrderByDescending(emp => emp.EmpName)) :
    		new ObservableCollection<Employee>(m.EmpName.Select(k => new Employee { EmpName = k, IsChecked = true }).ToList())
    }).ToDictionary(x => x.Dep, x => x.EmpCollection);
