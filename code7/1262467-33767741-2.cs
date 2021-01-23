    @(Html.Kendo().Grid<UserViewModel>()
        .Name("grid")
        .Columns(columns =>
        {
            columns.Bound(p => p.Username).Width(150).Title("User Name");
            columns.Bound(p => p.Role).Width(100).ClientTemplate("#=Role.RoleName#").Filterable(false).Width(80).Sortable(false);       
        })        
        .Pageable()
        .Sortable()        
        .DataSource(dataSource => dataSource
            .Ajax()               
            .PageSize(10)
            .Model(model =>
            {
                model.Id(p => p.ID);            
                model.Field(p => p.Role).DefaultValue(ViewData["defaultCategory"] as UserRole);
            }
            )
            
                    
                    .Read(read => read.Action("GetAllUser", "Administration"))
                                  
        )
    )
