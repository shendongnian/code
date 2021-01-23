    public ActionResult Index()
        {
            ViewBag.Region = new SelectList(db.DevRegions, "RegionID", "RegionName");
            var allzones = db.Zones.Include(z => z.devregion);
            return View(allzones.ToList());
        }
