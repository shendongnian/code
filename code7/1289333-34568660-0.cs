    public ActionResult Index()
    {
        
        IEnumerable<Teacher> teachers = Enumerable.Empty<Teacher>();
        string campus = Request.Params["Campus"];
        if (campus != null)
        {
            if (campus == "Alle")
            {
                teachers = (from t in db.Teachers
                            select t);
            }
            else
            {
                teachers = (from t in db.Teachers
                            where t.Campus == campus
                            select t );
            }
        }
        else
        {
            teachers = (from t in db.Teachers
                        select t);
        }
        var Model = new ViewModel
        {
            Teachers = teachers
        };
        return View(Model);
    }
