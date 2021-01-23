    public IEnumerable<tbl_QuizQue> Get()
    {
        var result = obj.tbl_QuizQue.OrderBy(r => Guid.NewGuid())
            .Select(o => new { o.id, o.question, o.opt1, o.opt2, o.opt3 })
            .AsEnumerable()
            .Select(q => new tblQuizQue {q.id, q.question, q.opt1, q.opt2, q.opt3);
        return result;
    }
