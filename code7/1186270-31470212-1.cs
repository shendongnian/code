    [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FAQ faq, List<int> printertypes)
        {
            PopulatePrintertypeDropDownList();
            foreach (int i in printertypes)
            {
                faq.printertype.Add(db.printertypeSatz.Find(i));
            }
            
            if (ModelState.IsValid)
            {
                db.FAQSatz.Add(faq);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(faq);
        }
