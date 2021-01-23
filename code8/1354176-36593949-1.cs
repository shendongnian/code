        public ActionResult Index()
        {
            var liste =  db.Locations.ToList();
            var listeTriee = liste.OrderBy(t => t.site_name);
            var viewModel = new ListeTrieeViewModel { ListeLocations = listeTriee; }
            return View(viewModel);
        }
