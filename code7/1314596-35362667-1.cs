    public ActionResult Index()
        {
            var results = db.Races.Where(r => r.Event_Id == id);
            if (results == null)
            {
                return HttpNotFound();
            }
            var items = new List<SelectListItem>();
            foreach (var r in results.ToList())
            {
                items.Add(new SelectListItem { Text = r.Name, Value = r.id.ToString() });
            }
            var pageSizes = new List<SelectListItem>();
            pageSizes.Add(new SelectListItem { Text = "5", Value = "5" });
            pageSizes.Add(new SelectListItem { Text = "10", Value = "10" });
            pageSizes.Add(new SelectListItem { Text = "25", Value = "25" });
    
            var model = new IndexViewModel()
            {
                Races = items,
                PageSize = pageSizes
            };
            return View(model);
        }
