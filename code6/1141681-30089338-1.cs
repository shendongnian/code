    @model yourAssembly.RegisterViewModel
    @using (Html.BeginForm())
    {
      ....
      foreach(var role in Model.UserRoles)
      {
        @Html.RadioButtonFor(m => m.SelectedRole, role.ID, new { id = role.Name })
        <label for="@role.Name">@role.Name</label>
      }
      @Html.ValidationMessageFor(m => m.SelectedRole)
      ....
    }
