        List<int> userRoleIds = userToEdit.Roles.Select(r => r.Id).ToList();
        EditUser model = new EditUser()
        {
            Email = userToEdit.Email,
            UserName = userToEdit.UserName,
            Password = userToEdit.Password,
            Roles = _db.Roles.Select(role => new RoleCheckBox
            {
                Id = role.Id,
                IsChecked = userRoleIds.Contains(role.Id),
                Name = role.Name
            }).ToList()
        });
        return View(model);
