    Dictionary<string, ObservableCollection<Employee>> EmpList = DepList.Select(m => new 
    {
        Dep = m.DepName, EmpCollection = 
        new ObservableCollection<Employee>(	m.EmpName.Select(k => {
        m.sortEmpName == FilterListSortDirection.SortDirection.Ascending ? 
        new Employee() { EmpName = k, IsChecked = true }).ToList().OrderBy(e => e.EmpName)) : 
        new Employee() { EmpName = k, IsChecked = true }).ToList().OrderByDescending(e => e.EmpName))
    }
	).ToDictionary(x => x.Dep, x => x.EmpCollection);
