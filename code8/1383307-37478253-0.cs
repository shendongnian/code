    [HttpPost]
    public ActionResult IsLastQuestion(int idQuestion)
    {
        Question question = Manager.GetQuestion(idQuestion);
        List<Question> questions = Manager.SelectQuestions(question.idSurvey);
        if (questions.Count == Manager.GetCountQuestionsAnswered(question.idSurvey, SessionUser.PersonID))
        return true;
        else
            return false;
    }
