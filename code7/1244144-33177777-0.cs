        [HttpPost]
        public ActionResult Inquiry(Search search)
        {
            if (!ModelState.IsValid)
            {
                return View(search);
            }
            //so something with your posted model.
        }
