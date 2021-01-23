       @for (int i = 0; i < Model.Questions.Count(); i++)
       {
          @Html.HiddenFor(modelItem => Model.Questions[i].QuestionText)    
        
           for (int m = 0; m < Model.Question[i].Answers.Count(); m++)
           {
              @Html.HiddenFor(modelItem => Model.Questions[i].Answers[m].AnswerText)
           }
       }
