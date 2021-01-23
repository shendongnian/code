    public ActionResult Index()
    {
        using (ISession session = SessionFactory.OpenSession())
        {
            var persons = session.Query<Genre>().ToList();
    
            return View(persons);
        }
    }
