    var items = dbContext.Roles
                         .Select(c => new  SelectListItem
                                                         { 
                                                           Value = c.RoleID.ToString(),
                                                           Text = c.RoleName
                                                         });
