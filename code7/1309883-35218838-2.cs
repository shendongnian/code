    var answers = db.Answers..... // your previous query
    List<SectionVM> model = answers.GroupBy(x => x.Section).Select(x => new SectionVM
    {
        Title = x.Key,
        SubSections = x.GroupBy(y => y.SubSection).Select(y => new SubSectionVM
        {
            Title = y.Key,
            Questions = y.Select(z => new QuestionVM
            {
                QuestionID = z.QuestionID,
                QuestionText = z.QuestionText,
                ....
            }).ToList()
        }).ToList()
    }).ToList();
    return View(model);
