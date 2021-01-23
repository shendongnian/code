    @model YourAssembly.User
    // Some display properties of the user (Name etc.)
    ....
    @using (Html.BeginForm())
    {
      @Html.HiddenFor(m => m.ID) // so the user ID posts back
      @Html.LabelFor(m => m.Options.AbsolutePressPreference)
      @Html.DropDownFor(m => m.Options.AbsolutePressPreference, (SelectList)ViewBag.AbsolutePressOptions)
      // More selects for other options
      <input type="submit" value="Save Options" />
    }
