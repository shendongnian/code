    @for (var i = 0; i < Model.Questions.Count(); i++)
    {
        <p>@Model.Questions[i].Question</p>
        @for (var j = 0; j < Model.Questions[i].Answers.Count(); j++)
        {
            @Html.RadioButtonFor(m => m.Questions[i].SelectedAnswerId, Model.Questions[i].Answers[j].Id, new { id = "Question" + i.ToString() + "Answer" + j.ToString() })
            <label for="Question@(i)Answer@(j)">@Model.Questions[i].Answers[j].LabelText</label>
        }
    }
