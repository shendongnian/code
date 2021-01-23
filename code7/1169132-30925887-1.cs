       public ActionResult Index()
       {
          var model = new FooViewModel();
          model.Links = db.Links.ToList();
          model.Abouts = db.Abouts.ToList();
          model.Portfolios = db.Portfolios.ToList();
          model.Skills = db.Skills.ToList();
          return View(model);
       }
