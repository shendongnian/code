        public ActionResult Index()
        {
            CatalogViewModel model = new CatalogViewModel()
            {
                Catalogs = Catalogs(),
            };
            return View(model);
        }
