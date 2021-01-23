        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRole([Bind(Include = "Id, Name")] IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                db.Roles.Add(role);
                db.SaveChanges();
                //If everything is good, save changes and redirect the user to the page with the list of all the roles.
                return RedirectToAction("AllRoles");
            }
            //If data is not valid return the original view with what the user has filled in.
            return View(role);
        }
