    @model DataTable
    
    @(Html.Kendo().Grid(Model)
        .Name("Grid")
        .Columns(columns =>
        {
            foreach (System.Data.DataColumn column in Model.Columns)
            {
                switch (column.ColumnName)
                {
                    case "customerNotes":
                        columns.Bound(column.ColumnName);
                        break;
                }
            }
        })
        .Pageable(x => x.PageSizes(new int[] { 10, 20, 30, 50 }).Refresh(true))
        .Sortable()
        .Filterable()
        .Groupable()
    )
