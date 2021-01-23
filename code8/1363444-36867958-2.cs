    @model List<TestModel>
    
    @using (Html.BeginForm())
    {
         @for (int i = 0; i < Model.Count; i++)
         {
              <div>@Html.CheckBoxFor(m => m[i].IsChecked)</div>
         }
    }
