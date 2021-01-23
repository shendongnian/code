    public ActionResult SaveEdit(int id, [Bind(Include = "OldestFriendId, BestFrinedId")] Example example,
         Bind(Prefix="Oldest", Include = "FriendId, FirstName, MiddleName, LastName")] Friend oldest, 
         Bind(Prefix="Best", Include = "FriendId, FirstName, MiddleName, LastName")] Friend best) {
    if (ModelState.IsValid)
        {
            using (((WindowsIdentity)ControllerContext.HttpContext.User.Identity).Impersonate())
            {
                using (var _db = new exampleEntities())
                {
                   // do whatever processing you want on best and/or oldest
                   example.BestFriendId = best.FriendId;
                   example.OldestFriendId = oldest.FriendId;
                  
                   _db.Entry(example).State = EntityState.Modified;
                   _db.SaveChanges();
                 }
            }
        }
    }
