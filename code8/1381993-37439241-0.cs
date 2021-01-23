    public ActionResult GetAnswer(List<PossibleAnswerVM> possibleAnswers)
    {
        if (IsLastQuestion(possibleAnswers.FirstOrDefault().IdQuestion))
        {
              return View();
        }
        return null;
    }
    private static bool IsLastQuestion(int idQuestion)
    {
        var returnValue = false;
        
        Question question = Manager.GetQuestion(idQuestion);
        List<Question> questions = Manager.SelectQuestions(question.idAnketa);
                    
        if (questions.Count == Manager.GetCountQuestionsAnswered(question.idAnketa, SessionUser.PersonID))
        {
            returnValue = true;
        }                      
        return returnValue;
    }
