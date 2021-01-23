    AssignedRoleList = new List<string>();
    AssignedRoleList = _userBll.ReadUserRoles(userId);
    if (AssignedRoleList.Count > 0)
    {
        var source = new BindingSource {DataSource = AssignedRoleList.Select(x => new {Roles = x})};
        dgvAssignedRoles.DataSource = source;
    }
