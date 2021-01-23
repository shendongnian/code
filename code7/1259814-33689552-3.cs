     public ActionResult Index()
        {
            return View(new RegisterViewModel()
            {
                Products = db.Food.Select(x => x.Food).ToList()
            });
        }
