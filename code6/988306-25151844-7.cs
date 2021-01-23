    @model RegisterModel
    ...
    <p> A Role ID </p>
    @Html.EditorFor(x => x.RoleId, 
           new { DDLItems = Model.UserRoles, DDLUnselectedValue = "Select A Value..." })
    <p> A Second Role ID </p>
    @Html.EditorFor(x => x.RoleId2, 
           new { DDLItems = Model.UserRoles, DDLUnselectedValue = "Select A Value 2..." })
