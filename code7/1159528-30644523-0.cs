    List<SurveyVM> surveys = DbContext.Survey.Select(s=> new SurveyVM {
        ID = s.ID,
        Name = s.Name,
        Categories = s.Category.Select(c => new CategoryVM {
            ID = c.ID,
            Name = c.Name,
            Questions = c.Question.Select(q=> new QuestionVM {
                ID = q.ID,
                Title = q.Title,
                Score = q.Score
            }).ToList()
        }).ToList()
    }).SingleOrDefault();
