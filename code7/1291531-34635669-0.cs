    var newPrivilegeModel = new EmployeePrivilegeModel();
    newPrivilegeModel.PrivList = new List<bool>();
    foreach (CheckBox c in companiesTabItem)
    {
        if (c.IsChecked == true)
        {
            newPrivilegeModel.PrivList.Add(1);
        }
        else
        {
            newPrivilegeModel.PrivList.Add(0);
        }
    }
