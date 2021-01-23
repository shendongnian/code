    @(Html.Kendo().Grid<LineViewModel>()
          .Name("gridLines#=Id#")
          .Columns(columns =>
                   {
                       columns.Bound(c => c.Name).Title("Name");
                   })
          .DataSource(dataSource => dataSource
                                        .Ajax()
                                        .PageSize(5)
                                        .Read(read => read.Action("readbyrecord", "line", new { recordId = "#= Id #" }))
          )
          .Pageable()
          .Sortable()
          .ToClientTemplate())
