    [HttpGet]
    public ActionResult Index()
    {
        SecurityLoginVM model = new SecurityLoginVM();
        // Populate SelectedQuestions and QuestionList from the database
        return View(model);
    }
    [HttpPost]
    public ActionResult Index(SecurityLoginVM model)
    {
        // model.SelectedQuestions contains the 6 objects containing the QuestionID and the users Answer
        ....
    }
