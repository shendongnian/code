    var questionIds=results.TestQuestions.Select(tq=>tq.id).ToArray();
    db.TestQuestions
        .Include("TestAnswers")
        .Include("TestQuestionCriterionGroups.TestQuestionCriterions")
        .Include("TestTasks.TestQuestions.Question.Answers")
        .Where(tq=>questionIds.Contains(tq.id))
        .Load();
