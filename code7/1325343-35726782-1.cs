    public QuestionGroup GroupQuestions(questions) 
    {
       return = questions
                  .GroupBy(
                    r => new {
                        r.Answer,
                        r.Answered,
                        r.AnswerGridCorrect,
                        r.AnswerGridResponses,
                        r.CorrectCount,
                        r.Hint,
                        r.IncorrectCount,
                        r.QuestionNumber,
                        r.QuestionUId,
                        r.Locked,
                        r.Result,
                        r.ShownCount,
                        r.Tagged,
                        r.Text,
                        r.UserTestQuestionId
                    },
                    (key, results) => new QuestionGroup
                    {
                        Answer = key.Answer,
                        AnswerGridCorrect = key.AnswerGridCorrect,
                        AnswerGridResponses = key.AnswerGridResponses,
                        Answered = key.Answered,
                        CorrectCount = key.CorrectCount,
                        Hint = key.Hint,
                        IncorrectCount = key.IncorrectCount,
                        QuestionNumber = key.QuestionNumber,
                        QuestionUId = key.QuestionUId,
                        Locked = key.Locked,
                        Result = key.Result,
                        ShownCount = key.ShownCount,
                        Tagged = key.Tagged,
                        Text = key.Text,
                        UserTestQuestionId = key.UserTestQuestionId,
                        AnswerGrid = results
                          .Select((r, index) => new
                          {
                              AnswerId = r.AnswerId,
                              Text = r.AnswerText,
                              Correct = key.AnswerGridCorrect == null ? null : (bool?)Convert.ToBoolean(int.Parse(key.AnswerGridCorrect.Substring(index, 1))),
                              Response = key.AnswerGridResponses == null ? null : (bool?)Convert.ToBoolean(int.Parse(key.AnswerGridResponses.Substring(index, 1)))
                          })
                          .ToList()
                    }
    }
