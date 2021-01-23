    @model List<yourAssembly.QuestionVM>
    @using (Html.BeginForm())
    {
      for(int i = 0; i < Model.Count; i++)
      {
        @Html.HiddenFor(m => m[i].ID)
        @Html.DisplayFor(m => m[i].Text)
        for(int j = 0; j < Model[i].SubQuestions.Count; j++)
        {
          @Html.HiddenFor(m => m[i].SubQuestions[j].ID)
          @Html.DisplayFor(m => m[i].SubQuestions[j].Text)
          var id = string.Format("Hate-{0}", Model[i].SubQuestions[j].ID);
          @Html.RadioButtonFor(m => m[i].SubQuestions[j].Rating, "Hate", new { id = id })
          <label for="@id">Hate</label>
          id = string.Format("Like-{0}", Model[i].SubQuestions[j].ID);
          @Html.RadioButtonFor(m => m[i].SubQuestions[j].Rating, "Like", new { id = id })
          <label for="@id">Like</label>
          // ditto for 'Very Like'
        }
      }
      <input type="submit" />
    }
