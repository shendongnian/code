	var EmpList = DepList.ToDictionary(p => p.DepName, p =>
		{
			var empList = p.EmpName.Select(k => new Employee() { EmpName = k, IsChecked = true });
			if (p.sortEmpName == FilterListSortDirection.SortDirection.Ascending)
			{
				empList = empList.OrderBy(q => q.EmpName);
			}
			else if (p.sortEmpName == FilterListSortDirection.SortDirection.Descending)
			{
				empList = empList.OrderByDescending(q => q.EmpName);
			}
			return new ObservableCollection<Employee>(empList.ToList());
		});
