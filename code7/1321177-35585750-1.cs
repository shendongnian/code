    Survey survey;
    int sourceId = 1;
    using (var context = new YourDbContext())
    {
      survey = context.Surveys.Include(s => s.Questions).Single(s => s.Id == sourceId);
      var questions = survey.Questions.OfType<QuestionType1>();
      foreach (var question in questions)
      {
        context.Entry(question).Collection(q => q.Answers).Load();
      }
    }
    /* just for testing to check if Questions and Answers are correctly loaded... */
    Console.WriteLine(survey);
    foreach (var questionBase in survey.Questions)
    {
      Console.WriteLine("Question id " + questionBase.Id);
      var questionType1 = questionBase as QuestionType1;
      if (questionType1 != null)
      {
        foreach (var answer in questionType1.Answers)
        {
          Console.WriteLine("Answer " + answer.Id);
        }
      }
    }
