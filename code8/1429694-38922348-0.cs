      var RolesList = new List<SelectListItem>
                {
                    new SelectListItem { Value = string.Empty, Text = "Please select a Role..." }
                };
    
       RolesList.AddRange(roles.Select(t => new SelectListItem
                {
                    Text = t.role,
                    Value = t.Id.ToString()
                }));` 
