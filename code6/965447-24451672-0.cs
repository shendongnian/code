    //first step
        var tests = db.Tests
            .Include(t => t.Exam)
            .Where(t => t.TestStatusId == 1);
    
            //next step
            if(testc.Exam != null && testc.Exam.Count > 0)
            {
                testc = testc.Select(t => new TestDTO
            {
                ExamName = t.Exam.Name,
                Id = t.TestId,
                QuestionsCount = t.QuestionsCount,
                Title = t.Title
            });
            }
