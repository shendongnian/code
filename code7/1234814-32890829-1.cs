        [Post]
        public actionresult edituser(int? id)
        {
        if (id == null)
           {
         return HttpNotFound();
           }
        
           using (var db = new UserContext())
        {
         UserModel editUser = db.UserModel.Find(id);
         if (editUser == null)
        {
        return HttpNotFound();
        }
    
    db.User(editModel).State = System.Data.Entity.EntityState.Modified;
    db.SaveChanges();
    }
    RedirectToAction("Action", "Controller");
    }
