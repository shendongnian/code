    [HttpPost]
        public ActionResult Search(string searchTerm)
        {
            return View(searchTerm);
        }
    }
