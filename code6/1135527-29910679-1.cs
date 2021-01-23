    for(int i = 0; i < Model.Categories.Count; i++)
    {
      @Html.CheckBoxFor(m => m.Categories[i].IsSelected)
      @Html.LabelFor(m => m.Categories[i].IsSelected, Model.Categories[i].Name)
      @Html.HiddenFor(m => m.Categories[i].ID)
      @Html.HiddenFor(m => m.Categories[i].Name)
    }
