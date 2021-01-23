    var result = await db.TestQuestions
                     .Where(t => t.TestId == testId)
                     .AsEnumerable()    // notice the AsEnumerable() call
                     .Select((t, index) => new GetAllDTO
                     {
                         QuestionUId = t.QuestionUId,
                         QuestionNumber = index
                     }).ToListAsync();
