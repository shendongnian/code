    Dictionary<string, ObservableCollection<Employee>> EmpList = DepList.Select(m => new 
    {
        Dep = m.DepName, EmpCollection = 
        new ObservableCollection<Employee>(	m.EmpName.Select(k =>
			new Employee() { EmpName = k, IsChecked = true }).ToList().Sort())
    }
	).ToDictionary(x => x.Dep, x => x.EmpCollection);
