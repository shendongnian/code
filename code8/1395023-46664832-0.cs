        [ActionName("Index")]
        public ActionResult Prueba()
        {
            return View(db.Corps.ToList());
        }
