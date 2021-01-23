    @model List<Rep.Models.ContactReportSettingViewModel>
    @using (Html.BeginForm())
    {
      @for (int i = 0; i < Model.Count; i++)
      {
        @Html.LabelFor(m => m[i].AccountNumber)
        @Html.TextBoxFor(m => m[i].AccountNumber)
        @Html.ValidationMessageFor(m => m[i].AccountNumber)
        .....
      }
      <input type="submit" .../>
    }
