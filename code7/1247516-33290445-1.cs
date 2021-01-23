     [OutputCache(Duration = int.MaxValue, VaryByParam = "id")]
        public ActionResult Details(int id)
        {
            ViewData.Model = _dataContext.Movies.SingleOrDefault(m => m.Id ==    id);
            return View();
        }
