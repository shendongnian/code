    public ActionResult Index()
    {
        using (ISession session = NHibernateHelper.OpenSession())
        {
            var persons = session.Query<Genre>().ToList();
    
            return View(persons);
        }
    }
