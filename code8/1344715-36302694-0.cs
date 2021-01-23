    [Post]
    public ActionResult Add(User u) {
         // Need to define 'db' as a Data connection
         db.Users.Add(u);
         db.SubmitChanges();
         return View(u);
    }
    
    
    [Post]
    public ActionResult Update(User u) {
         // Need to define 'db' as a Data connection
         var updatedUser = db.Users.Where(k=>k.Id == u.Id).FirstOrDefault();
         updatedUser = u;
         db.SubmitChanges();
         return View(updatedUser);
    }
