    [HttpPost]
    public ActionResult Create(FlatManagement FlatTable)
    {
        FlatInfo model = FlatTable.Flat; // this is the instance you need to update
        if (ModelState.IsValid)
        {
            var getUser = db.Clients.Where(a => a.username == User.Identity.Name).FirstOrDefault();
            model.admin_id = getUser.serial;
            model.user_id = 0;
            model.user_name = "N/A";
            model.user_phone = "N/A";
            db.FlatInfoes.Add(model);
            db.SaveChanges();
         }
         return View();
     }
