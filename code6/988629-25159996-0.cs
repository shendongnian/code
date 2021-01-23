    @for (var i = 0; i < Model.List.Count(); i++)
    {
      @Html.HiddenFor(model => Model.List[i].UserId)
      @Html.HiddenFor(model => Model.List[i].Name)
      @Html.HiddenFor(model => Model.List[i].Age)
    
      @Html.CheckBoxFor(model => Model.List[i].IsChecked, new { id = Model.List[i].UserId })
      <label>@Model.List[i].Name</label>
    }
