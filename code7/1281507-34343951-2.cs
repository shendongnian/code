    public ActionResult Index(int? Year, int? Qtr, string Div)
    {
        var data= db.JobRecaps.AsQueryable();
        if(Year.HasValue)
            data= data.Where(x=>x.Year == Year);
        if(Qtr.HasValue)
            data= data.Where(x=>x.Qtr == Qtr );
        if(!string.IsNullOrEmpty(Div))
            data= data.Where(x=>x.Div == Div );   
     
        return View(data.ToList());
    }
