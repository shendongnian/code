    @model yourAssembly.OrderVM
    @using (Html.BeginForm())
    {
      for(int i = 0; i < Model.Inventory.Count; i++)
      {
        @Html.HiddenFor(m => m.Inventory[i].ID)
        @Html.CheckBoxFor(m => m.Inventory[i].IsSelected)
        @Html.LabelFor(m => m.Inventory[i].IsSelected, Model.Inventory[i].Name)
      }
      @Html.TextBoxFor(m => m.PayentMethod)
      <input type="submit" value="Create" />
    }
