    public ActionResult Edit()
    {
      List<QuestionVM> model = new List<QuestionVM>();
      // Populate it from the database, but for testing
      model.Add(new QuestionVM()
      {
        ID = 1,
        Text = "What Fruit You Like ?",
        SubQuestions = new List<SubQuestionVM>()
        {
          new SubQuestionVM() { ID = 1, Text = "Apple" }, // include Rating="Hate" (or some value) if you want a default radio button selected
          new SubQuestionVM() { ID = 2, Text = "Orange" },
          new SubQuestionVM() { ID = 3, Text = "Grapes" }
        }
      });
      return View(model);
    }
