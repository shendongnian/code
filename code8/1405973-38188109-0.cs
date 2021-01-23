    if (!ModelState.IsValid)
        {
            app = db.Users.SingleOrDefault(u => u.UserName == model.Email);
            app.Lastloggedin = DateTime.Now;
            db.Entry(app).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("SignedIn");
        }    
