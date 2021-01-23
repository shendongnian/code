    @model yourAssembly.SurveyVM
    @using (Html.BeginForm())
    {
      // add elements for properties of SurveyVM (ID, Title etc)
      for(int i = 0; i < Model.Categories.Count; i++)
      {
        <div class="category">
          // add elements for properties of each CategoryVM (ID, Title etc)
          @for (int j = 0; j < Model.Categories[i].Questions.Count; j++)
          {
            <div class="question">
              @Html.HiddenFor(m => m.Categories[i].Questions[j].Id)
              @Html.DisplayFor(m => m.Categories[i].Questions[j].Title)
              @Html.TextBoxFor(m => m.Categories[i].Questions[j].Score)
            </div>
          }
        </div>
      }
      <input type="submit" .../>
    }
