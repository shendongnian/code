    var answersGroupedBySession = _dbContext.Answers
    .Where(p => p.Location.Company.Id == id 
               && p.Question.Type == QuestionType.Text
               && p=>!String.IsNullOrEmpty(p.Text))
    .GroupBy(g => g.Session, items => items, (key, value) => new
    {
        Session = key,
        Answers = value.OrderBy(f => f.DateCreated)
    }).ToList();
