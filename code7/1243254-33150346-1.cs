    var itemGroups = Model.Items.OrderBy(i => i.Name)
                           .ThenByDescending(i => i.OrderDate)
                           .GroupBy(x => new {
                                i.ID, 
                                i.DepartmentID,
                                i.Name,
                                i.OrderDate });
