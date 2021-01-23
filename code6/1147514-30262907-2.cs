    public something() { public string mix {get;set;}}
    public PartialViewResult showall()
    {
        //initially getting data from DB
        var task1 = from r in _db.Task1
                where r.Status == true
                orderby r.Post_Date descending
                select new Totaldata
                {
                 id = SqlFunctions.StringConvert((double)r.Task1_ID),
                 dt = r.Post_Date,
                 typ = "Task1"
                };
        HttpContext.Cache.Insert(key: "Task1Data",
                             value: task1, 
                             dependencies: null, 
                             absoluteExpiration: DateTime.Now.AddHours(5), 
                             slidingExpiration: System.Web.Caching.Cache.NoSlidingExpiration
                             );
        var task1Cache = (System.Web.HttpContext.Current.Cache["Task1Data"] as IQueryable<Totaldata>);
        var task1list = from a in task1Cache
                    select new Totaldata
                    {
                     id = SqlFunctions.StringConvert((double)a.Task1_ID),
                     dt = a.Post_Date,
                     typ = a.typ 
                    }; 
        var task2 = from r in _db.Task2
                orderby r.Post_Date descending
                select new Totaldata
                {
                 id = SqlFunctions.StringConvert((double)r.Task2_ID),
                 dt = r.Post_Date,
                 typ = "Task2"
                };
        HttpContext.Cache.Insert(key: "Task2Data",
                             value: task2, 
                             dependencies: null, 
                             absoluteExpiration: DateTime.Now.AddHours(5), 
                             slidingExpiration: System.Web.Caching.Cache.NoSlidingExpiration
                             );
        var task2Cache = (System.Web.HttpContext.Current.Cache["Task2Data"] as IQueryable<Totaldata>);
        var task2list = from a in task2Cache
                    select new Totaldata
                    {
                     id = SqlFunctions.StringConvert((double)a.Task2_ID),
                     dt = a.Post_Date,
                     typ = a.typ 
                    }; 
        var listc = task1list.Union(task2list);
        var q3 = (from r in listc 
                     select new something
                     {
                         mix = r.typ + "~" + r.id
                     }).ToList();
        return PartialView("~/Views/Ex/_ShowAll.cshtml", q3);
    }
