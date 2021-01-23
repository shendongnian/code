    @model yourAssembly.Survey
    @using (Html.BeginForm())
    {
      <h2>@Html.DisplayFor(m => m.Title)</h2>
      <h3>Yes/No questions</h3>
	  for(int i = 0; i < Model.YesNoQuestions.Count; i++)
	  {
	    <div>	
		  @Html.CheckBoxFor(m => m.YesNoQuestions[i].Answer)
		  @Html.LabelFor(m => m.YesNoQuestions[i].Answer, Model.YesNoQuestions[i].Text)
        </div>
      }
	  <h3>Text questions</h3>
	  for(int i = 0; i < Model.TextQuestions.Count; i++)
	  {
		@Html.LabelFor(m => m.TextQuestions[i].Answer, Model.TextQuestions[i].Text)
		@Html.TextAreaFor(m => m.TextQuestions[i].Answer)
      }
	  <h3>Multiple choice questions</h3>
	  for(int i = 0; i < Model.MultipleChoiceQuestions.Count; i++)
      {
	    <div>@Html.DisplayFor(m => m.MultipleChoiceQuestions[i].Text)</div>
		foreach(var option in Model.MultipleChoiceQuestions[i].PossibleAnswers)
		{
		  var id = string.Format("option-{0}", option.ID);
		  <div>
		    @Html.RadioButtonFor(m => m.MultipleChoiceQuestions[i].Answer, option.ID, new { id = id })
			<label for="@id">@option.Text</label>
		  </div>
		}
	  }
	  <input type="submit" value="Save" />
	}
