    public ActionResult Show(int? id)
    {
       //defining result as var is sufficient 
       var result = db.StatData
             .GroupBy(k => new { k.QuestId, k.OptionId })
             .Select(c => new Grouped//<<-here
             {
                 OptionId = c.Select(q => q.OptionId).FirstOrDefault(),
                 Counted = c.Select(q => q.id).Count(),
             }).ToList();//commit the query
             var viewModel = new StatsView();
             viewModel.Groupeds = result;//No need for casting
       return View(viewModel);
    }
