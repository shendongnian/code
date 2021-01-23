    public ActionResult Index()
            {
                var selectQuestion = (from q in questions.QUESTIONTABLEs
                                     select new QuestionModels{ /*... */}).ToList();
                return View(selectQuestion);
            }
