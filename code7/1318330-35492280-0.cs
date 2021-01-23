    @using (Html.BeginForm("index", "QuestionFormResponses", FormMethod.Post))
    {
        @Html.AntiForgeryToken()
    if (Model != null)
    {
        for (int i = 0; i < Model.Answers.Count; i++)
        {
            <table>
                <tr><th>
                    @Html.DisplayFor(a => a.Answers[i].QuestionCategoryColumn.QuestionCategory.Category)
                </th></tr>
                <tr>
                    <td>@Html.DisplayFor(a => a.Answers[i].QuestionCategoryColumn.ColumnName)</td>
                    <td>@Html.DisplayFor(a => a.Answers[i].Question.QuestionText)</td>
                    <td>@Html.TextBoxFor(a => a.Answers[i].QuestionAnswer)</td>
                </tr>
            </table>
        }
              <input type="submit" value="Submit" class="btn btn-default"/>
     }
    }
