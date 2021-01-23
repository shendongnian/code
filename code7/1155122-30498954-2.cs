    @model List<SurveyTool.Models.AnswerQuestionViewModel>
    @using (Html.BeginForm())
    {
        for(int i = 0; i < Model.Count; i++)
        {
            @Html.DisplayFor(m => m[i].Question)
            @Html.EditorFor(m => m[i].Answer)
        }
        <input type="submit" />
    }
