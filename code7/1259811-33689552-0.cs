     public ActionResult Index()
        {
            return View(new RegisterViewModel()
            {
                FoodsModel = db.Food.Select(x => x.Food).ToList()
            });
        }
