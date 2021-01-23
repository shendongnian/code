    public ActionResult GetNextQuestion(int? orderByKey, int? position)
    {
        var order = orderByKey ?? new Random().Next();
        var pos = position ?? 1;
    
        var que = GetQue(order, pos);
    
        return View(que);
    }
    
    public Tuple<dynamic, int> GetQue(int orderBy, int skip)
    {
        using (var obj = new Db())
        {
            var result = obj.tblQuestions
               .OrderBy(r => r.id % orderBy)
               .Select(o => new { o.id, o.Question, o.Opt1, o.Opt2, o.Opt3, o.Opt4 });
    
            if (skip > 0)
                result = result.Skip(skip);
    
            return Tuple.Create(result.First(), orderBy);
        }
    }
