    public ActionResult Question()
    {
      var vm = new QuestionViewModel { Id=2, QuestionText="What is your dream"};
      vm.OfferedAnswers = new List<Answer>{
           new Answer { Id=1, AnswerText="Get a job" },
           new Answer { Id=2, AnswerText="Buy a car" },
           new Answer { Id=3, AnswerText="Buy a boat" },
      };
      return View(vm);
    }
