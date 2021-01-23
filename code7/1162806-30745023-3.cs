    @for (int j = 0; j < Model[i].Roles.Count; j++)
    { 
      @Html.HiddenFor(m => m[i].Roles[j].Name) // or better use the ID property
      @Html.CheckBoxFor(m => m[i].Roles[j].IsSelected)
      @Html.LabelFor(m => m[i].Roles[j].IsSelected, Model[i].Roles[j].Name)
    }
