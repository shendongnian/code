     [HttpGet]
     public ActionResult GetNames()
     {
        return Json(db.UserNames.Take(5).ToList(), JsonRequestBehavior.AllowGet);
     }
    
     [HttpPost]
     public ActionResult Delete(int id)
     {
         // delete user:
         UserName userName = db.UserNames.Find(id);
         db.UserNames.Remove(userName);
         db.SaveChanges();
    
         // TODO: find new user here and return as JSON:
         return Json(new UserName { FullName = "User 6", Id = 6 });
     }
