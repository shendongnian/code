    var roles = db.RoleTables.ToList();
    emp.Role = GetSelectListItems(roles);
    private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<RoleTable> elements)
            {
                foreach (var element in elements)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.Id,
                        Text = element.Name
                    });
                }
    
                return selectList;
            }
