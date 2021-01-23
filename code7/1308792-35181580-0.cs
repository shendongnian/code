    var submitted =
        (from ans in db.Answers
            join ques in db.Questions on ans.QuestionId equals ques.QuestionId
            join resp in db.Responses on ans.ResponseId equals resp.ResponseId
            join sec in db.Sections on ques.SectionId equals sec.SectionId
            where sec.SectionId == 2 && resp.ResponseId == 12 && ques.SubSectionName != null
            select new { SubSectionName = ques.SubSectionName, RatingAnswer = ans.RatingAnswer })
        .GroupBy(a => a.SubSectionName)
        .Select(a => new { SectionName = a.Key, Sum = a.Sum(s => s.RatingAnswer) });
