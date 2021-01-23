       @for (int i = 0; i < Model.Question.Count(); i++)
       {
          @Html.HiddenFor(modelItem => Model.Question[i].QuestionText)    
        
           for (int m = 0; m < Model.Questions[i].Answers.Count(); m++)
           {
              @Html.HiddenFor(modelItem => Model.Questions[i].Answers[m].AnswerText)
           }
       }
