     [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
               
                return View(model);
            }
            ApplicationDbContext db = new ApplicationDbContext();
            ApplicationUser logged = db.Users.SingleOrDefault(u => u.UserName == model.Email);
            logged.Lastloggedin = DateTime.Now;
            db.Entry(logged).State = EntityState.Modified;
            db.SaveChanges();
