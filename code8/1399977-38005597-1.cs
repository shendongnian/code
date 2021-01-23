        [HttpPost]
        public ActionResult New(FormCollection _col)
        {
            using (DBContext db = new DBContext())
            {
                ValidateFormCollection(_col);
                if (ModelState.IsValid)
                {
                    User user = new User();
                    user.Name = _col["Name"].ToString();
                    user.Email = _col["Email"].ToString();
                    db.Users.Add(user);
                    db.SaveChanges();
                    return View("Index");
                }
                else
                {
                    return View();
                }
            }
        }
        private void ValidateFormCollection(FormCollection _col)
        {
            if (string.IsNullOrEmpty(_col["Name"].ToString()))
                ModelState.AddModelError("Name", "The Name field is required.");
            if (string.IsNullOrEmpty(_col["Email"].ToString()))
                ModelState.AddModelError("Email", "The Email field is required.");
        }
