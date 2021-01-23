    public ActionResult MemberSearch()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MemberSearch(ViewModesTest m)
        {
            var d = db.Members.Where(s => s.Name == m.Name && m.LastName).ToList();
            return PartialView("SearchResutl", d);
        }
