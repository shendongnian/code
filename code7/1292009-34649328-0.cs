    @(Html.Kendo().Grid<MvcApplication1.Models.Student>()
        .Name("Grid")
            //.Columns(columns =>
            //   {
            //       columns.Bound(c => c.StudentID);
            //       columns.Bound(c => c.StudentName);
            //   })
         .Columns(cols => cols.LoadSettings(ViewBag.cols))
            .Scrollable()
            .Groupable()
            .Sortable()
            .Editable(editable => editable.Mode(GridEditMode.InLine)).ToolBar(toolbar => toolbar.Create())
            .Pageable(pageable => pageable
                .Refresh(true)
                .PageSizes(true)
                .ButtonCount(5))
           .Events(events => events.Edit("onEdit"))
            .DataSource(dataSource => dataSource
                .Ajax()
                .Read(read => read.Action("Grid_Read", "Home"))
                .Update(update => update.Action("EditingInline_Update", "Grid"))
                  .Create(update => update.Action("EditingInline_Create", "Grid"))
                 .Model(model =>
            {
                model.Id(p => p.StudentID);
                model.Field(p => p.StudentID).Editable(true);
            })
            )
    )
   
