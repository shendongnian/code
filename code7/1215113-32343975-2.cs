    @model yourAssembly.StudentVM
    @using(@Html.BeginForm("Index", "Home", FormMethod.Get)) {
      @Html.LabelFor(m => m.Paging)
      @Html.DropDownListFor(m => m.Paging, Model.PageList)
    }
    @{
      var webGird = new WebGrid(
        Model.Students, rowsPerPage: Model.Paging, // modify this
        ....
