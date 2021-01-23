    NewRoleList = new List<string>();
    // Assigned Old user roles to the new one.
    if (AssignedRoleList != null) NewRoleList = AssignedRoleList;
    foreach (var v in dataviewform.SeletedDataList)
    {
        bool status = true;
        // Check if user already have the roles
        if (dgvAssignedRoles.Rows.Cast<DataGridViewRow>().Any(row => Equals(row.Cells[0].Value, v)))
        {
            MessageBox.Show("Role already exist.");
            status = false;
        }
        // Adding the new selected roles to the existence user role if not present
        if (status)
            NewRoleList.Add(v);
        }
        // Finally attaching the both new and old user roles to datagridview
        var source = new BindingSource {DataSource = NewRoleList.Select(x => new {Roles = x})};
        dgvAssignedRoles.DataSource = source;
    }
