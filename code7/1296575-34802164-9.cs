    QuestionnaireVM model = new QuestionnaireVM
    {
      Groups = db.Questions.GroupBy(x => x.AreaName).Select(x => new QuestionGroupVM
      {
        Name = x.Key,
        Questions = x.Select(y => new QuestionVM
        {
          ID = y.StnAssureQuestionId,
          Question = y.Question,
          Score = y.Score,
          Comments = y.Comments
        }
      },
      Scores = new SelectList(.....)
    };
    return View(model);
