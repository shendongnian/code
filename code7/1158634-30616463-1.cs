    public ActionResult Index()
    {
      SurveyVM model = new SurveyVM();
      // populate the categories and for each category, populate the associated questions
      return View(model);
    }
    [HttpPost]
    public ActionResult Index(SurveyVM model)
    {
      // loop through each Category, and foreach category loop through each Question to build your `List<QuestionResult>`
    }
