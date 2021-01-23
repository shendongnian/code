    @for(int i = 0; i < Model.ListRole.Count; i++)
    {
        if(Model.UserRole.Contains(Model.ListRole[i]))
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
