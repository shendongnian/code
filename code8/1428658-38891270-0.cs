    public ActionResult EditUser(int Id)
        {
            var db = new UserDbContext();
            var usr = db.Users.Where(a => a.Id == Id).SingleOrDefault();
            if (usr == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound, "User not found");
            Response.StatusCode = 400;
            return View(usr);
        }
 
