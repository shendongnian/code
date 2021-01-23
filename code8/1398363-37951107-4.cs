    [HttpPost]
    public ActionResult Question(QuestionViewModel model)
    {
      var answers = model.OfferedAnswers.Where(s=>s.IsSelected);
      // to do return something.
    }
