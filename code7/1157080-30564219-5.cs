    @model yourAssembly.Book
    @using (Html.BeginForm())
    {
      for(int i = 0; i < Model.Count; i++)
      {
        @Html.TextBoxFor(m => m[i].Title)
        @Html.ValidationMessageFor(m => m[i].Title)
        .... // ditto for other properties of Book
      }
      <input type="submit" .. />
    }
