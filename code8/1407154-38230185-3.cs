    public ActionResult GetNextQuestion(int[] prevs = null)
    {
        var que = GetQue(prevs);
        var ids = new int[] { que.id};
    
        if(prevs != null)
            ids = ids.Concat(prevs);
        ViewBag.list = ids;
    
        return View(que);
    }
    
    
    
    public dynamic GetQue(int[] prevs = null)
    {
        using (var obj = new Db())
        {
            var result = obj.tblQuestions;
    
            if(prevs != null)
               result = result.Where(e => !prevs.Contains(e.id));
    
            result = result.OrderBy(r => new Guid())
                           .Select(o => new { o.id, o.Question, o.Opt1, o.Opt2, o.Opt3, o.Opt4 });
    
            return result.First();
        }
    }
