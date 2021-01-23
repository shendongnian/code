    @model List<yourAssembly.OptionVM>
    @using (Html.BeginForm())
    {
      for (int i = 0; i < Model.Count; i++)
      {
        <label>
          @Html.CheckBoxFor(m => m[i].IsSelected)
          <span>@Model[i].Text</span>
        </label>
        @Html.TextBoxFor(m => m[i].Answer)
        @Html.ValidationMessageFor(m => m[i].Answer)
      }
      <input type="submit" ... />
    }
