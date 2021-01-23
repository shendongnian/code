    @model UserTitleVM
    @using (Html.BeginForm())
    {
      ....
      for(int i = 0; i < Model.Titles.Count; i++)
      {
        @Html.HiddenFor(m => m.Titles[i].ID)
        @Html.CheckBoxFor(m =>m.Titles[i].IsSelected)
        @Html.LabelFor(m => m.Titles[i].IsSelected, Model.Titles[i].Name)
      }
