    @for(int i = 0; i < Model.ListRole.Count; i++)
    {
        if(Model.UserRole.Select(x => x.Name).Contains(Model.ListRole[i].Name))
        {
           @Html.HiddenFor(m => m.ListRole[i].ID)
           @Html.CheckBoxFor(m => m.ListRole[i].IsSelected, new { @checked = "checked" }); 
           @Html.LabelFor(m => m.ListRole[i].IsSelected, Model.ListRole[i].Name)
        }
        else
        {
           @Html.HiddenFor(m => m.ListRole[i].ID)
           @Html.CheckBoxFor(m => m.ListRole[i].IsSelected); 
           @Html.LabelFor(m => m.ListRole[i].IsSelected, Model.ListRole[i].Name)
        }
    }
