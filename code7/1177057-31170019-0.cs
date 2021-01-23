    <style>
        .k-grid-edit .k-icon, .k-grid-update .k-icon, .k-grid-cancel .k-icon {
            margin: 0px !important;
        }
    </style>
    
    
    @(Html.Kendo().Grid<MvcApplication1.Models.TestModel>()
      .Name("LightsGrid")
      .Columns(col =>
      {
          col.Bound(x => x.ID);
          col.Command(command =>
          {
              command.Edit()
                 .Text(" ")
                 .UpdateText(" ")
                 .CancelText(" ");
    
          });
    
      })
      .ToolBar(toolbar => toolbar.Create())
      .Editable()
      .DataSource(dataSource => dataSource
          .Ajax()
          .Model(model => model.Id(x => x.ID))
          .Read(read => read.Action("GetData", "Home"))
          .Create(create => create.Action("CreateData", "Home"))
          .Update(update => update.Action("UpdateData", "Home"))
          .Destroy(destroy => destroy.Action("DestroyData", "Home"))
      )
    )
