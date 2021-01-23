    var items = Model.Items.GroupBy(x => new {
                                i.ID, 
                                i.DepartmentID,
                                i.Name,
                                i.OrderDate })
                           .OrderBy(i => i.Name)
                           .ThenByDescending(i => i.OrderDate);
