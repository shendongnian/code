    public ActionResult Index(int? page)
    {
         var questions = new[] {
               new QuestionViewModel { QuestionId = 1, QuestionName = "Question 1" },
               new QuestionViewModel { QuestionId = 1, QuestionName = "Question 2" },
               new QuestionViewModel { QuestionId = 1, QuestionName = "Question 3" },
               new QuestionViewModel { QuestionId = 1, QuestionName = "Question 4" }
         };
    
         int pageSize = 3;
         int pageNumber = (page ?? 1);
         return View(questions.ToPagedList(pageNumber, pageSize));
    }
