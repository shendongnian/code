    public ActionResult Chestionar()
    {
      // Get data model and map to view models
      var model = db.FormQuestions.Select(q => new QuestionVM()
      {
        ID = q.idQuestion,
        Question = q.Question,
        Answer = .....,
        Document = .... // see notes below
      };
      return View(model);
    }
    [HttpPost]
    public ActionResult Chestionar(IEnumerable<QuestionVM> model)
    {
      if (!ModelState.IsValid)
      {
        return View(model);
      }
      // Get the data model again, map the view model properties back to the data model
      // update properties such as user and date
      // save and redirect
    }
