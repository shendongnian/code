    public ActionResult Index()
        {
            var model = new Models.UploadVideoPage.UploadVideoPageModel();
            PopulateDependencies(model);
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(Models.UploadVideoPage.UploadVideoPageModel model)
        {
            PopulateDependencies(model);
            return View(model);
        }
    
        private void PopulateDependencies(Models.UploadVideoPage.UploadVideoPageModel model)
        {
            model.categoria = new List<Models.UploadVideoPage.ListCategorie>();
            model.categoria.Add(new ListCategorie { TitoloCategoria = "Volontariato", idCategoria = 1 });
            model.categoria.Add(new ListCategorie { TitoloCategoria = "Interno", idCategoria = 2 });
            model.categoria.Add(new ListCategorie { TitoloCategoria = "Sindacato", idCategoria = 3 });
        }
