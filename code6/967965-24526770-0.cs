    var result = await db.Tests
            .Include(t => t.TestQuestions)
            .Where(t => t.TestId == id)
            .Select(t => new TestAndQuestionDTO
            {
                Name = t.Title,
                TestQuestions = t.TestQuestions.Select(tq => new TestAndQuestionDTO.Questions
                {
                    QuestionUId = tq.QuestionUId,
                    //fill in your Questions DTO here
                }
            })
            .ToListAsync();
