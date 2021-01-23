	if (objListEmp != null)
	{
		// To remove Deleted user from list
		var sorted = from employee in objListEmp
					 where !employee.Value.Contains("InActive")
					 select employee;
					 
		cmbAssignedSelector.DataSource = new BindingSource(sorted, null);
		cmbAssignedSelector.DisplayMember = "Value";
		cmbAssignedSelector.ValueMember = "Key";
	}
	else
	{
		cmbAssignedSelector.SelectedIndex = 0;
	}
