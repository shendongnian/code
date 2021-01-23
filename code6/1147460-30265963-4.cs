    var questionIds=results.TestQuestions.Select(tq=>tq.Guid).ToArray();
    db.TestQuestions
        .Include("TestQuestionCriterionGroups.TestQuestionCriterions")
        .Include("TestTasks.TestQuestions.Question.Answers")
        .Where(tq=>questionIds.Contains(tq.Guid))
        .Load();
