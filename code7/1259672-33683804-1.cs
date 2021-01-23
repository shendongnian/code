    @model IList<Example>
    ....
    @for(int i = 0; i < Model.Count; i++)
    {
      @Html.DropDownListFor(m => m[i].FilePath, new SelectList(ViewBag.ConfigFiles, "Value", "Text", Model[i].FilePath), string.Empty, null)
    }
