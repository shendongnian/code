    @model List<ContentVM>
    ....
    @using (Html.BeginForm())
    {
      for(int i = 0; i < Model.Count; i++)
      {
        @Html.HiddenFor(m => m[i].LanguageCode)
        @Html.LabelFor(m => m[i].ContentName, Model[i].LanguageName)
        @Html.TextBoxFor(m => m[i].ContentName)
        @Html.ValidationMessageFor(m => m[i].ContentName)
      }
      <input type=submit" ... />
    }
