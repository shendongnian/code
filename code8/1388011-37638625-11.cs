    @model RecipeManager.ViewModels.AdminViewModel
    ....
    @using (Html.BeginForm("UpdateRoles", "Admin", FormMethod.Post))
    {
        @Html.EditorFor(m => m.UserRoles, new { RoleTypes = Model.RoleTypes })
        <input type="submit" value="Update Roles" />
    }
    
