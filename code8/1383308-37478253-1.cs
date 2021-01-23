    [HttpPost]
    public ActionResult IsLastQuestion(int idQuestion)
    {
        Question question = Manager.GetQuestion(idQuestion);
        List<Question> questions = Manager.SelectQuestions(question.idSurvey);
        if (questions.Count == Manager.GetCountQuestionsAnswered(question.idSurvey, SessionUser.PersonID))
        return Json(new { Success = true, Result = "True" }, JsonRequestBehavior.AllowGet);
        else
            return Json(new { Success = true, Result = "False" }, JsonRequestBehavior.AllowGet);
    }
