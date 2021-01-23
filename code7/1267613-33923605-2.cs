    @(Html.Kendo().Grid<MyApplication.Models.CustomerViewModel>()
      .Name("grid")
      .Columns(columns =>
      {
          columns.Bound(c => c.ID).Title("Code");
          columns.Bound(c => c.companyName).Title("Company Name");
          columns.Bound(c => c.address).Title("Address");
          columns.Bound(c => c.addressNumber).Title("Street").Width(60);
          columns.Bound(c => c.zipCode).Title("ZIP Code").Width(60);
          columns.Bound(c => c.city).Title("City").Width(80);
          columns.Bound(c => c.province).Title("Province").Width(45);
      })
      .Editable(editable => editable.Mode(GridEditMode.InCell))
      .Sortable(sortable =>
      {
          sortable.SortMode(GridSortMode.MultipleColumn);
      })
      .Scrollable()
      .HtmlAttributes(new { style = "height: 710px; top: -25px" })
      .ToolBar(toolbar =>
      {
          toolbar.Create();
          toolbar.Save();
          toolbar.Excel();
          toolbar.Pdf();
      })
      .DataSource(dataSource => dataSource
          .Ajax()
           .Model(mdl =>
           {
             mdl.Id("ID");//Tell the grid which field is the id
             mdl.Field(fld => fld.ID).Editable(false);//Make the id field read only
           })
          .Batch(true)
          .Read(read => read.Action("CustomerListViewModels_Read", "Customer"))
          .Create(create => create.Action("CustomerViewModels_Create", "Customer", new { id = "#:data.ID#" }))
          .Update(update => update.Action("CustomerViewModels_Update", "Customer"))
          .Destroy(destroy => destroy.Action("CustomerViewModels_Destroy", "CustomerList"))
      )
     .Events(events => events.Edit("onEdit"))
        )
