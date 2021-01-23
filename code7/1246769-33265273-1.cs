    for (var i = 0; i < Model.UnAuthUsers.Count; i++)
    
     using (Html.BeginForm("Manage", "Admin", FormMethod.Post))
                    {
                        @Html.HiddenFor(x => x.UnAuthUsers[i].UserName)
                        @Html.HiddenFor(x => x.UnAuthUsers[i].Email)
    
                        <input type="submit" value="Manage" />
