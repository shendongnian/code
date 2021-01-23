    // GET: /Admin/ImpersonateVendor
        public ActionResult ImpersonateVendor()
        {
            ImpersonateVendorViewModel model = new ImpersonateVendorViewModel();
            var vendors = (from c in db.Vendors
                            select c).ToList();
            model.Vendors = vendors; --> add list here
            return View(model);
        }
