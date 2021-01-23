    var roles = db.RoleTables.ToList();
                empreg.Role = GetSelectListItems(roles);
                foreach (var item in empreg.Role)
                {
                    if (item.Value == SelectedRole)
                    {
                        item.Selected = true;
                    }
                }
