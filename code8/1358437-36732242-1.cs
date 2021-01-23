    QuestionVM model = new QuestionVM()
    {
        ID = 1,
        Description = "If you could return to the past, what would you choose?",
        PossibleAnswers = new List<PossibleAnswer>()
        {
            new PossibleAnswer(){ ID = 1, Description = "Apply to another university" },
            new PossibleAnswer(){ ID = 2, Description = "Apply to the same ...", RequireAdditionalText = true }
        }
    };
    return View(model);
