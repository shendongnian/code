    @model IList<EnrollSys.Employee>
    @using (Html.BeginForm("Save"))
    {
      for (int i = 0; i < Model.Count; i++)
      {
        @Html.TextBoxFor(m => m[i].name)
      }
      <input type="submit" value="Save" class="btn btn-default" style="width: 20%" />
    }
