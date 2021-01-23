    @model yourAssembly.SelectUserVM
    @using(Html.BeginForm()) 
    {
      foreach(var user in Model.AllUsers)
      {
        @Html.RadioButtonFor(m => m.SelectedUser, user.ID, new { id = user.ID })
        <label for="@user.ID">@user.Name</label>
      }
      <input type="submit" .. />
    }
