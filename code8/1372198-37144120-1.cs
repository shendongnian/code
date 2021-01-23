    <form asp-controller="Answer" asp-action="AnswerMe" method="post">
        @for(int i = 0; i < Model.Questions.Length; i++) {
            @Html.HiddenFor(m => m.Questions[i].Id)
            <br />
            for(int j = 0; j < m.Questions[i].QuestionAlternatives.Count; j++) {
                @Html.LabelFor(m => m.Questions[i].QuestionAlternatives[j].Alternative,m.Questions[i].QuestionAlternatives[j].Text)
                @Html.TextAreaFor(m => m.Questions[i].QuestionAlternatives[j].Alternative)
            }
        }
     
        <input type="submit" class="button" value="Answer" />
    </form>
 
